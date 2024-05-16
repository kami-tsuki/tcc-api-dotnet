namespace TCC.API.models.authentication.DataTransfer;

public class TokenDto 
{
    public ulong? Id { get; set; } 
    public string? Username { get; set; }
    public ulong? RoleId { get; set; }
    public string? Token { get; set; }
    public bool Authenticated => Token != null;

    public static implicit operator TokenDto(User user) => new()
    {
        Id = user.Id,
        Username = user.Username,
        RoleId = user.RoleId
    };
    
    public TokenDto WithToken(string token)
    {
        Token = token;
        return this;
    }
}