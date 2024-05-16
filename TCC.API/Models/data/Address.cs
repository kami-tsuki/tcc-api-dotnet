namespace TCC.API.Models.data;

public class Address : BaseEntity
{
    public ulong UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string? Complement { get; set; }
    public string? Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public string? Reference { get; set; }
    public string? Description { get; set; }
    
    public State Status { get; set; }
    
    [InverseProperty(nameof(TravelEntry.Origin))]
    public IEnumerable<TravelEntry> Origins { get; set; }
    
    [InverseProperty(nameof(TravelEntry.Destination))]
    public IEnumerable<TravelEntry> Destinations { get; set; }
    
    
}