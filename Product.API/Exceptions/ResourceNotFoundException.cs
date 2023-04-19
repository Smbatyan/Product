namespace Product.API.Exceptions;

public class ResourceNotFoundException : ApplicationExceptionBase
{
    public ResourceNotFoundException(string message) : base(message, 404)
    {
    }
}