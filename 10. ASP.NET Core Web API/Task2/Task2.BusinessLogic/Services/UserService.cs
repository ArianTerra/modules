using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Task2.BusinessLogic.DTO;
using Task2.BusinessLogic.Errors;
using Task2.DataAccess.Identity;

namespace Task2.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<Result<Guid>> RegisterUserAsync(UserRegisterDto dto)
    {
        var user = _mapper.Map<IdentityUser>(dto);

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            return Result.Fail(new InternalServerError(result.Errors.FirstOrDefault()?.Description));
        }

        var createdUser = await _userManager.FindByNameAsync(user.UserName);

        if (createdUser == null)
        {
            return Result.Fail(new InternalServerError("User was not created"));
        }

        //role setup
        await SetupRoles();

        if (await _roleManager.RoleExistsAsync(dto.Role))
        {
            await _userManager.AddToRoleAsync(createdUser, dto.Role);
        }
        else
        {
            return Result.Fail(new BadRequestError($"Role {dto.Role} does not exist. Use User, Instructor, Manager or Admin."));
        }

        return Result.Ok(Guid.Parse(createdUser.Id));
    }

    public async Task<Result<TokenDto>> LoginUserAsync(UserLoginDto dto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName);

        if (user == null)
        {
            return Result.Fail(new BadRequestError("Username or password is incorrect"));
        }

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, dto.Password);

        if (!isPasswordCorrect)
        {
            return Result.Fail(new BadRequestError("Username or password is incorrect"));
        }

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var userRoles = await _userManager.GetRolesAsync(user);

        foreach (var userRoleName in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRoleName));

            var role = await _roleManager.FindByNameAsync(userRoleName);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                authClaims.Add(claim);
            }
        }

        var token = GetToken(authClaims);

        var tokenDto = new TokenDto
        {
            JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
            ValidTo = token.ValidTo
        };

        return Result.Ok(tokenDto);
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }

    private async Task SetupRoles()
    {
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            var adminRole = await _roleManager.FindByNameAsync("Admin");
            await AddClaimIfNotExists(adminRole, Permissions.CanRead);
            await AddClaimIfNotExists(adminRole, Permissions.CanCreate);
            await AddClaimIfNotExists(adminRole, Permissions.CanEdit);
            await AddClaimIfNotExists(adminRole, Permissions.CanDelete);
        }

        if (!await _roleManager.RoleExistsAsync("Moderator"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Moderator"));
            var moderatorRole = await _roleManager.FindByNameAsync("Moderator");
            await AddClaimIfNotExists(moderatorRole, Permissions.CanRead);
            await AddClaimIfNotExists(moderatorRole, Permissions.CanCreate);
            await AddClaimIfNotExists(moderatorRole, Permissions.CanEdit);
        }

        if (!await _roleManager.RoleExistsAsync("Instructor"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Instructor"));
            var instructorRole = await _roleManager.FindByNameAsync("Instructor");
            await AddClaimIfNotExists(instructorRole, Permissions.CanRead);
            await AddClaimIfNotExists(instructorRole, Permissions.CanCreate);
        }

        if (!await _roleManager.RoleExistsAsync("User"))
        {
            await _roleManager.CreateAsync(new IdentityRole("User"));
            var userRole = await _roleManager.FindByNameAsync("User");
            await AddClaimIfNotExists(userRole, Permissions.CanRead);
        }
    }

    private async Task AddClaimIfNotExists(IdentityRole role, string permission)
    {
        var claims = await _roleManager.GetClaimsAsync(role);

        var claim = claims.Where(x => x.Value == permission).FirstOrDefault();

        if (claim == null)
        {
            await _roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, permission));
        }
        else
        {
            await _roleManager.AddClaimAsync(role, claim);
        }
    }
}