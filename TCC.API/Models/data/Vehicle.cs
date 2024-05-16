namespace TCC.API.Models.data;

public class Vehicle : BaseEntity
{ 
    public string Brand { get; set; }  = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Plate { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public ulong UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public State Status { get; set; }
    
    [InverseProperty(nameof(TravelEntry.Vehicle))]
    public IEnumerable<TravelEntry> TravelEntries { get; set; } = new List<TravelEntry>();
    
    public ulong? DocumentId { get; set; }
    
    [ForeignKey(nameof(DocumentId))]
    public Document Document { get; set; }
}