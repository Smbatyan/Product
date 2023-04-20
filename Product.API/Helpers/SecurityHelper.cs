using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Product.API.Settings;

namespace Product.API.Helpers;

public class SecurityHelper
{
    private readonly JwtSettings _jwtSettings;

    public SecurityHelper(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }
    
    public string GenerateJwtToken(string userName)
    {
        var issuer = _jwtSettings.Issuer;
        var audience = _jwtSettings.Audience;
        var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userName", userName)
            }),
            Expires = DateTime.UtcNow.AddSeconds(_jwtSettings.ExpiresIn),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };
        
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string jwtToken = tokenHandler.WriteToken(token);
        return jwtToken;
    }
}