using FluentResults;

namespace Task2.BusinessLogic.Errors;

public class NotFoundError : Error
{
    public NotFoundError(Guid id) : base($"Item with ID {id} not found in the database")
    {
        Metadata.Add("ErrorCode", ErrorCodes.NotFound);
    }
}