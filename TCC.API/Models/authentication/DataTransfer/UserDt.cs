namespace TCC.API.models.authentication.DataTransfer;

public class UserDt 
{
    public int? Id { get; set; } 
    public string? Username { get; set; }
    public int? RoleId { get; set; }
    public string? Token { get; set; }
    public bool Authenticated => Token != null;

    public static implicit operator UserDt(User user) => new UserDt
    {
        Id = user.Id,
        Username = user.Username,
        RoleId = user.RoleId
    };
    
    public UserDt WithToken(string token)
    {
        Token = token;
        return this;
    }
}