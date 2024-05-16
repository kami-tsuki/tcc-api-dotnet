namespace TCC.API.Models.authentication.dto;

public class RegisterDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public static implicit operator User(RegisterDto register) =>
        new()
        {
            Username = register.Username,
            Password = register.Password,
            Email = register.Email,
            RoleId = TccDbContext.DefaultRoles.SingleOrDefault(r => r.Name == "User")?.Id ?? 1UL
        };
}