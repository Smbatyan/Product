namespace Product.API.Exceptions;

public class UnauthorizedException : ApplicationExceptionBase
{
    public UnauthorizedException(string message) : base(message, 401)
    {
    }
}