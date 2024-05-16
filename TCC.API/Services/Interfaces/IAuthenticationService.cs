namespace TCC.API.Services.Interfaces;

public interface IAuthenticationService
{
    Task<TokenDto?> AuthenticateAsync(string username, string password);
    Task<User?> GetUserById(string userId);
}