namespace TCC.API.Services;

public class AuthenticationService(
    TccDbContext context, 
    ITokenService tokenService)
    : IAuthenticationService
{
    public async Task<TokenDt?> Authenticate(string username, string password)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Username == username.ToLower() && u.Password == password);
        if (user == null) return null;
        TokenDt token = user;
        return token.WithToken(tokenService.GenerateToken(user));
    }
}