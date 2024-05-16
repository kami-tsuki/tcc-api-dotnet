namespace TCC.API.Models.authentication.dto;

public class LoginDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public static implicit operator User(LoginDto login) => new()
    {
        Username = login.Username,
        Password = login.Password
    };
}