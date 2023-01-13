using FluentResults;
using FluentValidation.Results;

namespace Task2.BusinessLogic.Errors;

public class ValidationError : Error
{
    public ValidationError(ValidationResult validationResult) : base("Validation error")
    {
        Metadata.Add("ErrorCode", ErrorCodes.ValidationError);
        Metadata.Add("ValidationResult", validationResult);
    }
}