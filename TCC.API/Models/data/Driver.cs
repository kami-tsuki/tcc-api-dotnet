namespace TCC.API.Models.data;

public class Driver : BaseEntity
{
    
    public string Name { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public State Status { get; set; }
    
    [InverseProperty(nameof(TravelEntry.Driver))]
    public IEnumerable<TravelEntry> TravelEntries { get; set; } = new List<TravelEntry>();
    
    public ulong? UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    
    public ulong? DocumentId { get; set; }
    
    [ForeignKey(nameof(DocumentId))]
    public Document Document { get; set; }
}