using FluentResults;

namespace Task2.BusinessLogic.Errors;

public class InternalServerError : Error
{
    public InternalServerError(string message) : base(message)
    {
        Metadata.Add("ErrorCode", ErrorCodes.InternalServerError);
    }
}