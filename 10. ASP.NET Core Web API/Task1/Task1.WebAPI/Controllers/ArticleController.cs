using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Task1.BusinessLogic.DTO;
using Task1.BusinessLogic.Services;

namespace Task1.WebAPI.Controllers;

[ApiController]
[Route("api/articles")]
public class ArticleController : ControllerBase
{
    private readonly IArticleService _articleService;
    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? nameStartsWith = null)
    {
        var itemsCount = await _articleService.GetArticleCountAsync(nameStartsWith); //TODO remove this logic to business
        var pageCount = (int)Math.Ceiling((double)itemsCount / pageSize);
        if (pageCount == 0)
        {
            pageCount = 1;
        }

        if (page <= 0 || page > pageCount)
        {
            return BadRequest();
        }

        var articles = await _articleService.GetArticlesPageAsync(page, pageSize, nameStartsWith);

        Response.Headers.Add("X-Total-Count", itemsCount.ToString());
        return Ok(articles);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArticleDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var article = await _articleService.GetArticleByIdAsync(id);

        if (article == null)
        {
            return NotFound();
        }

        return Ok(article);
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] ArticleDto articleDto)
    {
        if (articleDto == null)
        {
            return BadRequest();
        }

        await _articleService.AddArticleAsync(articleDto);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ArticleDto articleDto)
    {
        if (articleDto == null)
        {
            return BadRequest();
        }

        await _articleService.UpdateArticleAsync(articleDto);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var article = await _articleService.GetArticleByIdAsync(id);
        if (article == null)
        {
            return NotFound();
        }

        await _articleService.DeleteArticleByIdAsync(id);

        return Ok();
    }
}