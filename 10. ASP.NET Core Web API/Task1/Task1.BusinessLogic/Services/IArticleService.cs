using Task1.BusinessLogic.DTO;

namespace Task1.BusinessLogic.Services;

public interface IArticleService
{
    Task<IEnumerable<ArticleDto>> GetArticlesPageAsync(int page, int pageSize, string? nameStartsWith = null);

    Task<ArticleDto> GetArticleByIdAsync(Guid id);

    Task AddArticleAsync(ArticleDto articleDto);

    Task UpdateArticleAsync(ArticleDto articleDto);

    Task DeleteArticleByIdAsync(Guid id);

    Task<int> GetArticleCountAsync(string name);
}