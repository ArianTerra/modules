using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Task2.BusinessLogic.Services;
using Task2.BusinessLogic.Services.Interfaces;
using Task2.BusinessLogic.Validators;
using Task2.DataAccess;
using Task2.DataAccess.DomainModels;
using Task2.DataAccess.Repository;

namespace Task2.WebAPI;

public static class CustomServiceExtension
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BusinessLogic.MappingProfile));

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IUserService, UserService>();

        //materials
        services.AddScoped<IValidator<ArticleMaterial>, ArticleMaterialValidator>();
        services.AddScoped<IArticleMaterialService, ArticleMaterialService>();
    }
}