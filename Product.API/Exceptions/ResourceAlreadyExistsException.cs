namespace Product.API.Exceptions;

public class ResourceAlreadyExistsException: ApplicationExceptionBase
{
    public ResourceAlreadyExistsException(string message) : base(message, 409)
    {
    }
}