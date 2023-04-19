using System.Net;
using System.Net.Mime;
using Newtonsoft.Json;
using Product.API.Contracts.Response;
using Product.API.Exceptions;

namespace Product.API.Extensions;

internal static class ErrorResponseExtension
{
    private const string ErrorMessage = "Something went wrong";

    internal static async Task GenerateApplicationErrorResponse(
        this ApplicationException httpResponseException,
        HttpContext httpContext)
    {
        ApplicationExceptionBase exception = httpResponseException as ApplicationExceptionBase;
        httpContext.Response.StatusCode = exception.StatusCode;

        ErrorResponse errorResponse = new() { Message = httpResponseException.Message };

        string errorJson = JsonConvert.SerializeObject(errorResponse);
        await httpContext.Response.WriteAsync(errorJson);
    }

    internal static async Task GenerateUnhandledErrorResponse(HttpContext httpContext)
    {
        httpContext.Response.ContentType = MediaTypeNames.Application.Json;

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        ErrorResponse errorResponse = new() { Message = ErrorMessage };
        string body = JsonConvert.SerializeObject(errorResponse);
        
        await httpContext.Response.WriteAsync(body);
    }
}