using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Task2.DataAccess;
using Task2.DataAccess.Identity;
using Task2.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext> (
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
    ),
    ServiceLifetime.Transient);

builder.Services.AddCustomServices();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Permissions.CanRead, policy => policy.RequireClaim(CustomClaimTypes.Permission, Permissions.CanRead));
    options.AddPolicy(Permissions.CanCreate, policy => policy.RequireClaim(CustomClaimTypes.Permission, Permissions.CanCreate));
    options.AddPolicy(Permissions.CanEdit, policy => policy.RequireClaim(CustomClaimTypes.Permission, Permissions.CanEdit));
    options.AddPolicy(Permissions.CanDelete, policy => policy.RequireClaim(CustomClaimTypes.Permission, Permissions.CanDelete));
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
});

// Adding Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
//app.UseMvc();

app.Run();