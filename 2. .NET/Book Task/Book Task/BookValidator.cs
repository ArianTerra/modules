using FluentValidation;

namespace Book_Task
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Name).NotEmpty().NotNull().Length(1, 100);
            RuleFor(book => book.Author).NotEmpty().NotNull().Length(1, 50);
            RuleFor(book => book.Format).NotEmpty().NotNull();
        }
    }
}