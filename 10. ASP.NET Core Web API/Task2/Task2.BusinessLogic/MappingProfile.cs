using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Task2.BusinessLogic.DTO;
using Task2.DataAccess.DomainModels;

namespace Task2.BusinessLogic;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ArticleMaterial, ArticleMaterialDto>();
        CreateMap<ArticleMaterialDto, ArticleMaterial>();

        CreateMap<UserRegisterDto, IdentityUser>();
    }
}