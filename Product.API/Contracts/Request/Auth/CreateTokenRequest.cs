namespace Product.API.Contracts.Request.Auth;

public class CreateTokenRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}