using Microsoft.Extensions.Options;
using Product.API.Contracts.Request.Auth;
using Product.API.Exceptions;
using Product.API.Helpers;
using Product.API.Settings;

namespace Product.API.Services;

public class AuthService
{
    private const string userName = "admin";
    private const string password = "admin";

    private readonly SecurityHelper _securityHelper;

    public AuthService(SecurityHelper securityHelper)
    {
        _securityHelper = securityHelper;
    }

    public string AuthenticateUser(CreateTokenRequest tokenRequest)
    {
        if (tokenRequest.UserName != userName && tokenRequest.Password != password)
        {
            throw new UnauthorizedException("Invalid username and/or password");
        }

        string jwtToken = _securityHelper.GenerateJwtToken(userName);
        return jwtToken;
    }
}