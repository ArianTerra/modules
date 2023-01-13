using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task2.BusinessLogic.DTO;
using Task2.BusinessLogic.Extensions;
using Task2.BusinessLogic.Services;

namespace Task2.WebAPI.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync(UserRegisterDto dto)
    {
        var userId = await _userService.RegisterUserAsync(dto);

        if (userId.IsFailed)
        {
            return StatusCode(userId.GetErrorCode(), userId.Errors.FirstOrDefault());
        }

        return Ok(userId.Value);
    }

    [HttpPost("authenticate")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(UserLoginDto dto)
    {
        var token = await _userService.LoginUserAsync(dto);

        if (token.IsFailed)
        {
            return StatusCode(token.GetErrorCode(), token.Errors.FirstOrDefault());
        }

        return Ok(token.Value);
    }
}