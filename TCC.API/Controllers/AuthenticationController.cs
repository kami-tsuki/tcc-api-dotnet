using Microsoft.Extensions.Options;
using TCC.API.Models.data.dto;
using static TCC.API.Services.TokenService;
using TokenValidationResult = TCC.API.models.authentication.DataTransfer.TokenValidationResult;

namespace TCC.API.Controllers;

[ApiController,
 Authorize,
 ApiVersion("1.0"),
 Route("api/v{version:apiVersion}/auth")]
public class AuthenticationController(
    IAuthenticationService authService,
    TccDbContext context,
    IOptionsMonitor<JwtBearerOptions> jwtOptions,
    IConfiguration configuration,
    ITokenService tokenService
)
    : BaseController(authService, context, jwtOptions, configuration, tokenService)
{
    private readonly TokenValidationParameters _tokenValidationParameters = jwtOptions.Get(JwtBearerDefaults.AuthenticationScheme).TokenValidationParameters;

    [HttpPost("login"), ApiVersion("1.0"), AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var user = await authService.AuthenticateAsync(login.Username, login.Password);
        if (user == null) return Unauthorized();
        return Ok(user);
    }

    [HttpPost("register"), ApiVersion("1.0"), AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterDto register)
    {
        var existingUser = await context.Users.SingleOrDefaultAsync(u => u.Username == register.Username);
        if (existingUser != null) return BadRequest("Username already exists");
        existingUser = await context.Users.SingleOrDefaultAsync(u => u.Email == register.Email);
        if (existingUser != null) return BadRequest("Email already exists");
        User? user = register;
        context.Users.Add(user);
        context.Settings.Add(new() { User = user, UserId = user.Id });
        await context.SaveChangesAsync();

        var authenticatedUser = await authService.AuthenticateAsync(user.Username, user.Password);
        if (authenticatedUser == null) return BadRequest("Error occurred during registration");
        return Ok(authenticatedUser);
    }

    [HttpGet("token/check"), ApiVersion("1.0"), AllowAnonymous]
    public IActionResult CheckToken([FromHeader(Name = AuthHeader)] string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var claimsPrincipal = tokenHandler.ValidateToken(
                token,
                ValidationParameters(configuration),
                out var validatedToken);
            var jwtToken = validatedToken as JwtSecurityToken;
            if (jwtToken == null) return Unauthorized(new TokenValidationResult { IsValid = false, Reason = "Invalid token" });
            var personalKey = jwtToken.Claims.First(c => c.Type == PersonalKeyClaim).Value;
            var userId = jwtToken.Claims.First(c => c.Type == UserIdClaim).Value;
            var user = context.Users.SingleOrDefault(u => u.Id.ToString() == userId);
            if (user == null) return Unauthorized(new TokenValidationResult { IsValid = false, Reason = "User not found" });
            if (user.PersonalKey != personalKey) return Unauthorized(new TokenValidationResult { IsValid = false, Reason = "Invalid personal key" });
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

    [HttpPost("logout"), ApiVersion("1.0"), Authorize]
    public async Task<IActionResult> Logout([FromHeader(Name = AuthHeader)] string token)
    {
        var (user, result, claimsPrincipal) = await GetUser();
        if (user == null || claimsPrincipal == null) return result ?? Unauthorized("Invalid token: User or ClaimsPrincipal is null");

        var personalKey = tokenService.ExtractClaim(claimsPrincipal, PersonalKeyClaim);
        if (personalKey == null
         || user.PersonalKey != personalKey)
            return Unauthorized("Invalid token: PersonalKey is invalid");

        user.PersonalKey = Guid.NewGuid().ToString();
        await context.SaveChangesAsync();

        return Ok("Logged out successfully");
    }

    [HttpPost("username/change"), ApiVersion("1.0"), Authorize]
    public async Task<IActionResult> ChangeUsername([FromBody] ChangeUsernameDto changeUsernameDto)
    {
        var (user, result, claimsPrincipal) = await GetUser();
        if (user == null || claimsPrincipal == null) return result ?? Unauthorized("Invalid token: User or ClaimsPrincipal is null");

        var existingUser = await context.Users.SingleOrDefaultAsync(u => u.Username == changeUsernameDto.NewUsername);
        if (existingUser != null) return BadRequest("Username already exists");

        user.Username = changeUsernameDto.NewUsername;
        await context.SaveChangesAsync();

        return Ok("Username changed successfully");
    }

    [HttpPost("email/change"), ApiVersion("1.0"), Authorize]
    public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailDto changeEmailDto)
    {
        var (user, result, claimsPrincipal) = await GetUser();
        if (user == null || claimsPrincipal == null) return result ?? Unauthorized("Invalid token: User or ClaimsPrincipal is null");

        var existingUser = await context.Users.SingleOrDefaultAsync(u => u.Email == changeEmailDto.NewEmail);
        if (existingUser != null) return BadRequest("Email already exists");

        user.Email = changeEmailDto.NewEmail;
        await context.SaveChangesAsync();

        return Ok("Email changed successfully");
    }

    [HttpPost("password/reset"), ApiVersion("1.0"), Authorize]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
    {
        var (user, result, claimsPrincipal) = await GetUser();
        if (user == null || claimsPrincipal == null) return result ?? Unauthorized("Invalid token: User or ClaimsPrincipal is null");
        var authenticatedUser = await authService.AuthenticateAsync(user.Username, resetPasswordDto.Old);
        if (authenticatedUser?.Authenticated == true) return BadRequest("Invalid password");
        user.Password = resetPasswordDto.New;
        user.PersonalKey = Guid.NewGuid().ToString();
        await context.SaveChangesAsync();
        return Ok("Password reset successfully");
    }

    [HttpGet("profile"), ApiVersion("1.0"), Authorize]
    public async Task<IActionResult> Profile()
    {
        var (user, result, claimsPrincipal) = await GetUser();
        if (user == null || claimsPrincipal == null) return result ?? Unauthorized("Invalid token: User or ClaimsPrincipal is null");
        return Ok((ProfileDto)user);
    }

    [HttpGet("settings"), ApiVersion("1.0"), Authorize]
    public async Task<IActionResult> GetSettings()
    {
        var (user, result, claimsPrincipal) = await GetUser();
        if (user == null || claimsPrincipal == null) return result ?? Unauthorized("Invalid token: User or ClaimsPrincipal is null");
        var settings = await context.Settings.FindAsync(user.Id);
        if (settings == null) return NotFound();

        return Ok(settings);
    }

    [HttpPut("settings"), ApiVersion("1.0"), Authorize]
    public async Task<IActionResult> UpdateSettings([FromBody] SettingsDto settingsDto)
    {
        var (user, result, claimsPrincipal) = await GetUser();
        if (user == null || claimsPrincipal == null) return result ?? Unauthorized("Invalid token: User or ClaimsPrincipal is null");
        var settings = await context.Settings.FindAsync(user.Id);
        if (settings == null) return NotFound();
        
        //TODO

        await context.SaveChangesAsync();

        return Ok("Settings updated successfully");
    }
}