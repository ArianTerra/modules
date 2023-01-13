using FluentResults;
using Task2.BusinessLogic.DTO;

namespace Task2.BusinessLogic.Services.Interfaces;

public interface IArticleMaterialService
{
    Task<Result<ArticleMaterialDto>> GetArticleByIdAsync(Guid id);

    Task<Result<IEnumerable<ArticleMaterialDto>>> GetArticlesPageAsync(int page, int pageSize,
        string? nameStartsWith = null);

    Task<Result<int>> GetArticlesCountAsync(string? nameStartsWith = null);

    Task<Result<Guid>> AddArticleAsync(ArticleMaterialDto materialDto);

    Task<Result> UpdateArticleAsync(ArticleMaterialDto materialDto);

    Task<Result> DeleteArticleByIdAsync(Guid id);
}