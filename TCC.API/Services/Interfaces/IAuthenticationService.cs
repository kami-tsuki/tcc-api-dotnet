namespace TCC.API.Services.Interfaces;

public interface IAuthenticationService
{
    Task<TokenDt?> Authenticate(string username, string password);
}