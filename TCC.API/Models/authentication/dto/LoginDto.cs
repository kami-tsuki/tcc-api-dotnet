namespace TCC.API.models.authentication.DataTransfer;

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }

    public static implicit operator User(LoginDto login) => new()
    {
        Username = login.Username,
        Password = login.Password
    };
}