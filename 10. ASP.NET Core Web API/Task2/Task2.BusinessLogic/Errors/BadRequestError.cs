using FluentResults;

namespace Task2.BusinessLogic.Errors;

public class BadRequestError : Error
{
    public BadRequestError(string message) : base(message)
    {
        Metadata.Add("ErrorCode", ErrorCodes.BadRequest);
    }
}