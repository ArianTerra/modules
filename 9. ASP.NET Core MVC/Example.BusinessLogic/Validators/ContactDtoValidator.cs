using Example.BusinessLogic.DTO;
using Example.DataAccess.DomainModels;
using Example.DataAccess.Repository;
using FluentValidation;

namespace Example.BusinessLogic.Validators;

public class ContactDtoValidator : AbstractValidator<ContactDto>
{
    private readonly IGenericRepository<Contact> _repository;

    public ContactDtoValidator(IGenericRepository<Contact> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Phone)
            .NotEmpty();
        // .MustAsync(async (phone, cancellation) =>
        // {
        //     var contact = await _repository.FindFirstAsync(x => x.Phone == phone);
        //     return contact == null;
        // })
        // .WithMessage("Phone already exists in contacts");
    }
}