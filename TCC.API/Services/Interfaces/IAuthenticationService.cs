using TCC.API.models.authentication.DataTransfer;

namespace TCC.API.Services.Interfaces;

public interface IAuthenticationService
{
    Task<UserDt?> Authenticate(string username, string password);
}