using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TCC.API.Data;
using TCC.API.models.authentication;
using TCC.API.models.authentication.DataTransfer;
using TCC.API.Services.Interfaces;

namespace TCC.API.Services;

public class AuthenticationService(
    TccDbContext context, 
    IEncryptionService encryptionService, 
    ITokenService tokenService)
    : IAuthenticationService
{
    public async Task<UserDt?> Authenticate(string username, string password)
    {
        var encryptedPassword = encryptionService.Encrypt(password);
        var user = await context.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == encryptedPassword);
        if (user != null) 
            return ((UserDt)user).WithToken(tokenService.GenerateToken(user));
        return new UserDt();
    }
}