namespace TCC.API.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}