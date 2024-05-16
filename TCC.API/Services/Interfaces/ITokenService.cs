namespace TCC.API.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
    ClaimsPrincipal? ValidateToken(string token, out SecurityToken validatedToken);
    string? ExtractClaim(ClaimsPrincipal claimsPrincipal, string claimType);
}