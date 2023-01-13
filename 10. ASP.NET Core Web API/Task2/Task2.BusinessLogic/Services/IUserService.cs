using FluentResults;
using Task2.BusinessLogic.DTO;

namespace Task2.BusinessLogic.Services;

public interface IUserService
{
    Task<Result<Guid>> RegisterUserAsync(UserRegisterDto dto);
    Task<Result<TokenDto>> LoginUserAsync(UserLoginDto dto);
}