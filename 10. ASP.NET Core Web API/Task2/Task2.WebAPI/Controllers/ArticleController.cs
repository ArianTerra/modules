using System.Net.Mime;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task2.BusinessLogic.DTO;
using Task2.BusinessLogic.Extensions;
using Task2.BusinessLogic.Services.Interfaces;
using Task2.DataAccess.Identity;

namespace Task2.WebAPI.Controllers;

[ApiController]
[Route("api/articles")]
public class ArticleController : ControllerBase
{
    private readonly IArticleMaterialService _articleService;
    public ArticleController(IArticleMaterialService articleService)
    {
        _articleService = articleService;
    }

    [Authorize(Policy = Permissions.CanRead)]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 30, [FromQuery] string? nameStartsWith = null)
    {
        var articleResult = await _articleService.GetArticlesPageAsync(page, pageSize, nameStartsWith);

        if (articleResult.IsFailed)
        {
            return StatusCode(articleResult.GetErrorCode());
        }

        var countResult = await _articleService.GetArticlesCountAsync(nameStartsWith);

        if (articleResult.IsFailed)
        {
            return StatusCode(countResult.GetErrorCode());
        }

        Response.Headers.Add("X-Total-Count", countResult.Value.ToString());
        return Ok(articleResult.Value);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Policy = Permissions.CanRead)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArticleMaterialDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var articleResult = await _articleService.GetArticleByIdAsync(id);

        if (articleResult.IsFailed)
        {
            return StatusCode(articleResult.GetErrorCode());
        }

        return Ok(articleResult.Value);
    }

    [HttpPost]
    [Authorize(Policy = Permissions.CanCreate)]
    public async Task<IActionResult> Post([FromBody] ArticleMaterialDto articleMaterialDto)
    {
        var articleResult = await _articleService.AddArticleAsync(articleMaterialDto);

        if (articleResult.IsFailed)
        {
            if (articleResult.GetErrorCode() == 422)
            {
                articleResult.GetValidationResult().AddToModelState(this.ModelState);
                return StatusCode(422, this.ModelState);
            }

            return StatusCode(articleResult.GetErrorCode());
        }

        return Ok();
    }

    [HttpPut]
    [Authorize]
    [Authorize(Policy = Permissions.CanEdit)]
    public async Task<IActionResult> Put([FromBody] ArticleMaterialDto articleMaterialDto)
    {
        var articleResult = await _articleService.UpdateArticleAsync(articleMaterialDto);

        if (articleResult.IsFailed)
        {
            if (articleResult.GetErrorCode() == 422)
            {
                articleResult.GetValidationResult().AddToModelState(this.ModelState);
            }

            return StatusCode(articleResult.GetErrorCode(), this.ModelState.Values);
        }

        return Ok();
    }

    [HttpDelete]
    [Authorize]
    [Authorize(Policy = Permissions.CanDelete)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var articleResult = await _articleService.DeleteArticleByIdAsync(id);

        if (articleResult.IsFailed)
        {
            return StatusCode(articleResult.GetErrorCode(), articleResult.Errors);
        }

        return Ok();
    }
}