namespace TCC.API.Models.authentication;

[Table("Users")]
public class User : BaseEntity
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
    
    [Required]
    public string Email { get; set; } = string.Empty;
    
    public ulong? RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
    
    [InverseProperty(nameof(Vehicle.User))]
    public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    
    [InverseProperty(nameof(Document.User))]
    public IEnumerable<Document> Documents { get; set; } = new List<Document>();
    
    [InverseProperty(nameof(Address.User))]
    public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
    
    [InverseProperty(nameof(Driver.User))]
    public IEnumerable<Driver> Drivers { get; set; } = new List<Driver>();
    
    [InverseProperty(nameof(TravelEntry.User))]
    public IEnumerable<TravelEntry> TravelEntries { get; set; } = new List<TravelEntry>();
    
    public ulong? SettingsId { get; set; }
    
    [ForeignKey(nameof(SettingsId))]
    public Settings? Settings { get; set; }
    
    [MaxLength(36)]
    public string PersonalKey { get; set; } = NewGuid().ToString(); 
}