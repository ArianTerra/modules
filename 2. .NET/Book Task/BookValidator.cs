using Book_Task.Models;
using Book_Task.Strings;
using FluentValidation;

namespace Book_Task
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Name).NotEmpty().NotNull().Length(1, 100)
                .WithMessage(book => BookValidationErrorMessages.Name);
            RuleFor(book => book.Author).NotEmpty().NotNull().Length(1, 50)
                .WithMessage(book => BookValidationErrorMessages.Author);
            RuleFor(book => book.Pages).GreaterThan(0)
                .WithMessage(book => BookValidationErrorMessages.Pages);
            RuleFor(book => book.Date).NotEmpty().NotNull().Must(BeDateOnlyOrYear)
                .WithMessage(book => BookValidationErrorMessages.Date);
            RuleFor(book => book.Format).NotEmpty().NotNull().Must(BePreferredType)
                .WithMessage(book => BookValidationErrorMessages.Format);
        }

        private bool BeDateOnlyOrYear(string value)
        {
            DateOnly date;
            if (DateOnly.TryParse(value, out date))
            {
                return true;
            }

            int year;
            if (int.TryParse(value, out year))
            {
                return true;
            }

            return false;
        }

        private bool BePreferredType(string value)
        {
            var preferredTypes = new List<string> { "pdf", "docx", "txt" };
            return preferredTypes.Contains(value);
        }
    }
}