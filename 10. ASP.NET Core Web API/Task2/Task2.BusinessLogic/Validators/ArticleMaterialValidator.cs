using FluentValidation;
using Task2.DataAccess.DomainModels;

namespace Task2.BusinessLogic.Validators;

public class ArticleMaterialValidator : AbstractValidator<ArticleMaterial>
{
    public ArticleMaterialValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Source).NotEmpty();
    }
}