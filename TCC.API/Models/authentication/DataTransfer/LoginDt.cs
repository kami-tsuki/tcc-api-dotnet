namespace TCC.API.models.authentication.DataTransfer;

public class LoginDt
{
    public string Username { get; set; }
    public string Password { get; set; }

    public static implicit operator User(LoginDt login) => new()
    {
        Username = login.Username,
        Password = login.Password
    };
}