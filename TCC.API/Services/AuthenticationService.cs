namespace TCC.API.Services;

public class AuthenticationService(
    TccDbContext context, 
    ITokenService tokenService)
    : IAuthenticationService
{
    public async Task<TokenDto?> AuthenticateAsync(string username, string password)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Username == username.ToLower() && u.Password == password);
        if (user == null) return null;
        TokenDto token = user;
        return token.WithToken(tokenService.GenerateToken(user));
    }
    
    public async Task<User?> GetUserById(string userId) => await context.Users.SingleOrDefaultAsync(u => u.Id.ToString() == userId);
}