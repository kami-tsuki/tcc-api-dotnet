namespace TCC.API.Models.data;

public class Settings : BaseEntity
{
    public ulong UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
}