namespace TCC.API.Models.data;

public class Vehicle : BaseEntity
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
    public string Color { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public ulong UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public State Status { get; set; }
    
    [InverseProperty(nameof(TravelEntry.Vehicle))]
    public IEnumerable<TravelEntry> TravelEntries { get; set; }
    
    public ulong? DocumentId { get; set; }
    
    [ForeignKey(nameof(DocumentId))]
    public Document Document { get; set; }
}