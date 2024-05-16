namespace TCC.API.models.authentication.DataTransfer;

public class RegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public static implicit operator User(RegisterDto register) =>
        new()
        {
            Username = register.Username,
            Password = register.Password,
            Email = register.Email,
            RoleId = TccDbContext.DefaultRoles.SingleOrDefault(r => r.Name == "User")?.Id ?? 1UL 
        };
}