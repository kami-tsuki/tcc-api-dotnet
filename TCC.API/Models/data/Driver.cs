namespace TCC.API.Models.data;

public class Driver : BaseEntity
{
    
    public string Name { get; set; }
    public string? Email { get; set; }
    public State Status { get; set; }
    
    [InverseProperty(nameof(TravelEntry.Driver))]
    public IEnumerable<TravelEntry> TravelEntries { get; set; }
    
    public ulong? UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    
    public ulong? DocumentId { get; set; }
    
    [ForeignKey(nameof(DocumentId))]
    public Document Document { get; set; }
}