namespace TCC.API.Models.data;

public class TravelEntry : BaseEntity
{
    public DateTime Date { get; set; }
    public ulong OriginId { get; set; }
    
    [ForeignKey(nameof(OriginId))]
    public Address Origin { get; set; }
    public ulong DestinationId { get; set; }

    [ForeignKey(nameof(DestinationId))]
    public Address Destination { get; set; }
    public string Description { get; set; }
    public ulong DocumentId { get; set; }
    
    [ForeignKey(nameof(DocumentId))]
    public Document Document { get; set; }
    public ulong UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public ulong DriverId { get; set; }
    
    [ForeignKey(nameof(DriverId))]
    public Driver Driver { get; set; }
    public ulong VehicleId { get; set; }
    
    [ForeignKey(nameof(VehicleId))]
    public Vehicle Vehicle { get; set; }
    
    public State Status { get; set; }
    public double Distance { get; set; }
    
    
}