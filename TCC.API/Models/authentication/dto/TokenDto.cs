namespace TCC.API.Models.authentication.dto;

public class TokenDto 
{
    public ulong? Id { get; set; }  
    public string? Username { get; set; } = string.Empty;
    public ulong? RoleId { get; set; }
    public string? Token { get; set; } = null;
    public bool Authenticated => string.IsNullOrWhiteSpace(Token);

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