namespace TCC.API.Models.data;

public class Document : BaseEntity
{
    [MaxLength(100)]
    public string Title { get; set; }
    
    [MaxLength(500)]
    public string Content { get; set; }
    
    [MaxLength(100)]
    public string Author { get; set; }
    
    public State Status { get; set; }
    public ulong UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } 
    
    [InverseProperty(nameof(TravelEntry.Document))]
    public IEnumerable<TravelEntry> TravelEntries { get; set; }
    
    [InverseProperty(nameof(Driver.Document))]
    public Driver Driver { get; set; }
    public ulong DriverId { get; set; }
    
    [InverseProperty(nameof(Vehicle.Document))]
    public Vehicle Vehicle { get; set; }
    public ulong VehicleId { get; set; }
}