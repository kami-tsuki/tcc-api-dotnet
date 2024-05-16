namespace TCC.API.Models.data.dto;

public class ProfileDto
{
    public ulong UserId { get; set; } 
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ulong? RoleId { get; set; }
    public ulong? SettingsId { get; set; }

    public static implicit operator ProfileDto(User user) => 
        new ProfileDto
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            RoleId = user.RoleId,
            SettingsId = user.SettingsId
        };
}