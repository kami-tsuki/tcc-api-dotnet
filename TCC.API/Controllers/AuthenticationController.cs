using TCC.API.models.authentication.DataTransfer;

namespace TCC.API.Controllers;

[ApiController,
 Authorize,
 ApiVersion("1.0"),
 Route("api/v{version:apiVersion}/[controller]")]
public class AuthenticationController(
    IAuthenticationService authService,
    TccDbContext context)
    : ControllerBase
{
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
        context.Users.Add(register);
        await context.SaveChangesAsync();
        var authenticatedUser = await authService.Authenticate(register.Username, register.Password);
        if (authenticatedUser == null) return BadRequest("Error occurred during registration");
        return Ok(authenticatedUser);
    }
}