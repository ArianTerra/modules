using Microsoft.EntityFrameworkCore;
using Task1.BusinessLogic.DTO;
using Task1.DataAccess.DomainModels;
using Task1.DataAccess.Repository;

namespace Task1.BusinessLogic.Services;

public class ArticleService : IArticleService
{
    private readonly IGenericRepository<Article> _articleRepository;

    public ArticleService(IGenericRepository<Article> articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<IEnumerable<ArticleDto>> GetArticlesPageAsync(int page, int pageSize, string? nameStartsWith = null)
    {
        if (page <= 0)
        {
            page = 1;
        }

        if (pageSize <= 0)
        {
            if (!string.IsNullOrEmpty(nameStartsWith))
            {
                pageSize = await GetArticleCountAsync(nameStartsWith);
            }
        }

        var articles = await _articleRepository.FindAll(
            filter: string.IsNullOrEmpty(nameStartsWith) ? _ => true : x => x.Name.StartsWith(nameStartsWith),
            page: page,
            pageSize: pageSize)
            .ToListAsync();

        //TODO use automapper
        return articles.Select(article => new ArticleDto
                { Id = article.Id, Name = article.Name, PublishDate = article.PublishDate, Source = article.Source })
            .ToList();
    }

    public async Task<ArticleDto> GetArticleByIdAsync(Guid id)
    {
        var article = await _articleRepository.FindFirstAsync(x => x.Id == id);

        if (article == null)
        {
            return null;
        }

        return new ArticleDto
        {
            Id = article.Id,
            Name = article.Name,
            PublishDate = article.PublishDate,
            Source = article.Source
        };
    }

    public async Task AddArticleAsync(ArticleDto articleDto)
    {
        var article = new Article()
        {
            Id = articleDto.Id,
            Name = articleDto.Name,
            PublishDate = articleDto.PublishDate,
            Source = articleDto.Source
        };

        await _articleRepository.AddAsync(article);
    }

    public async Task UpdateArticleAsync(ArticleDto articleDto)
    {
        var article = await _articleRepository.FindFirstAsync(x => x.Id == articleDto.Id);

        if (article == null)
        {
            throw new NotImplementedException();
        }

        article.Name = articleDto.Name;
        article.PublishDate = articleDto.PublishDate;
        article.Source = articleDto.Source;

        await _articleRepository.UpdateAsync(article);
    }

    public async Task DeleteArticleByIdAsync(Guid id)
    {
        var article = await _articleRepository.FindFirstAsync(x => x.Id == id);

        if (article == null)
        {
            throw new NotImplementedException();
        }

        await _articleRepository.RemoveAsync(article);
    }

    public async Task<int> GetArticleCountAsync(string? name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            return await _articleRepository.CountAsync(x => x.Name.StartsWith(name));
        }
        else
        {
            return await _articleRepository.CountAsync();
        }
    }

}