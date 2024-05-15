namespace TCC.API.models.authentication;

[Table("Roles")]
public class Role : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public ICollection<User> Users { get; set; }
}