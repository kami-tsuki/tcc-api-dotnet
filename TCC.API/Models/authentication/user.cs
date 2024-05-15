namespace TCC.API.models.authentication;

[Table("Users")]
public class User : BaseEntity
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Email { get; set; }

    public int? RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
}