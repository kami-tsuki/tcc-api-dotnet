namespace TCC.API.Models.data;

public class Address : BaseEntity
{
    public ulong UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } 

    [MaxLength(100)]
    public string Street { get; set; } = string.Empty;
    [MaxLength(10)]
    public string Number { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? Complement { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? Neighborhood { get; set; } = string.Empty;
    [MaxLength(50)]
    public string City { get; set; } = string.Empty;
    [MaxLength(50)]
    public string State { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Country { get; set; } = string.Empty;
    [MaxLength(10)]
    public string ZipCode { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? Reference { get; set; } = string.Empty;
    [MaxLength(500)]
    public string? Description { get; set; } = string.Empty;

    public State Status { get; set; }

    [InverseProperty(nameof(TravelEntry.Origin))]
    public IEnumerable<TravelEntry> Origins { get; set; } =  new List<TravelEntry>();

    [InverseProperty(nameof(TravelEntry.Destination))]
    public IEnumerable<TravelEntry> Destinations { get; set; } = new List<TravelEntry>();
}