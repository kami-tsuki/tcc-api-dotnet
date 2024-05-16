namespace TCC.API.Controllers;

public class BaseController(
    IAuthenticationService authService,
    TccDbContext context,
    IOptionsMonitor<JwtBearerOptions> jwtOptions,
    IConfiguration configuration,
    ITokenService tokenService
) : ControllerBase
{
    protected async Task<(User? user, IActionResult? result, ClaimsPrincipal? claimsPrincipal)> GetUser(string? token = null)
    {
        token ??= Request.Headers[AuthHeader];
        if (string.IsNullOrEmpty(token)) return (null, Unauthorized("Invalid token: Token is missing"), null);
        var claimsPrincipal = tokenService.ValidateToken(token, out _);
        if (claimsPrincipal == null) return (null, Unauthorized("Invalid token: ClaimsPrincipal is null"), claimsPrincipal);
        var userId = tokenService.ExtractClaim(claimsPrincipal, UserIdClaim);
        if (userId == null) return (null, Unauthorized("Invalid token: UserId claim is missing"), claimsPrincipal);
        var user = await authService.GetUserById(userId);
        if (user == null) return (null, Unauthorized("Invalid token: User not found"), claimsPrincipal);
        return (user, null, claimsPrincipal);
    }
}