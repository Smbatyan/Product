using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Product.API.Contracts.Request.Auth;
using Product.API.Services;

namespace Product.API.Endpoints.Auth;

[FastEndpoints.HttpPost("security/createToken"), AllowAnonymous]
public class CreateTokenEndpoint : Endpoint<CreateTokenRequest, string>
{
    private readonly AuthService _authService;

    public CreateTokenEndpoint(AuthService authService)
    {
        _authService = authService;
    }

    public override async Task HandleAsync(CreateTokenRequest req, CancellationToken ct)
    {
        string token = _authService.AuthenticateUser(req);
        
        await SendOkAsync(token);
    }
}