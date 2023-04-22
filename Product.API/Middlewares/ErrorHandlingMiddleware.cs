using Product.API.Extensions;

namespace Product.API.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ApplicationException appEx)
        {
            Console.WriteLine(
                $"Message : {appEx.Message}{Environment.NewLine}"); // Additional information can be added here

            await appEx.GenerateApplicationErrorResponse(httpContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Message : {ex.Message}{Environment.NewLine} Stack Trace : {ex.StackTrace}"); // Additional information can be added here

            await ErrorResponseExtension.GenerateUnhandledErrorResponse(httpContext);
        }
    }
}