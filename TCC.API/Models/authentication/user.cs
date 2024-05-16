using static System.Guid;

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
    
    public ulong? RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
    
    [InverseProperty(nameof(Vehicle.User))]
    public IEnumerable<Vehicle> Vehicles { get; set; }
    
    [InverseProperty(nameof(Document.User))]
    public IEnumerable<Document> Documents { get; set; }
    
    [InverseProperty(nameof(Address.User))]
    public IEnumerable<Address> Addresses { get; set; }
    
    [InverseProperty(nameof(Driver.User))]
    public IEnumerable<Driver> Drivers { get; set; }
    
    [InverseProperty(nameof(TravelEntry.User))]
    public IEnumerable<TravelEntry> TravelEntries { get; set; }
    
    public ulong? SettingsId { get; set; }
    
    [ForeignKey(nameof(SettingsId))]
    public Settings? Settings { get; set; }
    
    public string PersonalKey { get; set; } = NewGuid().ToString();
}