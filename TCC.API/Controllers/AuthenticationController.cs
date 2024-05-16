using Microsoft.Extensions.Options;
using TokenValidationResult = TCC.API.models.authentication.DataTransfer.TokenValidationResult;

namespace TCC.API.Controllers;

[ApiController,
 Authorize,
 ApiVersion("1.0"),
 Route("api/v{version:apiVersion}/[controller]")]
public class AuthenticationController(
    IAuthenticationService authService,
    TccDbContext context,
    IOptionsMonitor<JwtBearerOptions> jwtOptions,
    IConfiguration configuration
)
    : ControllerBase
{
    private readonly TokenValidationParameters _tokenValidationParameters = jwtOptions.Get(JwtBearerDefaults.AuthenticationScheme).TokenValidationParameters;

    [HttpPost("login"), ApiVersion("1.0"), AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDt login)
    {
        var user = await authService.Authenticate(login.Username, login.Password);
        if (user == null) return Unauthorized();
        return Ok(user);
    }

    [HttpPost("register"), ApiVersion("1.0"), AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterDt register)
    {
        var existingUser = await context.Users.SingleOrDefaultAsync(u => u.Username == register.Username);
        if (existingUser != null) return BadRequest("Username already exists");
        existingUser = await context.Users.SingleOrDefaultAsync(u => u.Email == register.Email);
        if (existingUser != null) return BadRequest("Email already exists");
        User user = register;
        context.Users.Add(user);
        context.Settings.Add(new() { User = user, UserId = user.Id });
        await context.SaveChangesAsync();

        var authenticatedUser = await authService.Authenticate(user.Username, user.Password);
        if (authenticatedUser == null) return BadRequest("Error occurred during registration");
        return Ok(authenticatedUser);
    }

    [HttpGet("checkToken"), ApiVersion("1.0"), AllowAnonymous]
    public IActionResult CheckToken([FromHeader(Name = "x-auth-token")] string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var claimsPrincipal = tokenHandler.ValidateToken(
                token,
                TokenService.ValidationParameters(configuration),
                out _);
            return Ok(new TokenValidationResult { IsValid = true, Reason = "Valid token" });
        }
        catch (SecurityTokenExpiredException e)
        {
            return Ok(new TokenValidationResult { IsValid = false, Reason = "Token has expired", Exception = e });
        }
        catch (SecurityTokenInvalidLifetimeException e)
        {
            return Ok(new TokenValidationResult { IsValid = false, Reason = "Token has an invalid lifetime", Exception = e });
        }
        catch (SecurityTokenInvalidSignatureException e)
        {
            return Ok(new TokenValidationResult { IsValid = false, Reason = "Token has an invalid signature", Exception = e });
        }
        catch (SecurityTokenInvalidIssuerException e)
        {
            return Ok(new TokenValidationResult { IsValid = false, Reason = "Token has an invalid issuer", Exception = e });
        }
        catch (SecurityTokenInvalidAudienceException e)
        {
            return Ok(new TokenValidationResult { IsValid = false, Reason = "Token has an invalid audience", Exception = e });
        }
    }
}