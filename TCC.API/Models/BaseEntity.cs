namespace TCC.API.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    [NotMapped]
    public User? CreatedByUser { get; set; }
    
    [NotMapped]
    public User? UpdatedByUser { get; set; }

    protected BaseEntity()
    {
        CreatedByUser = null;
        CreatedBy = 0;
        UpdatedBy = 0;
        UpdatedByUser = null;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsDeleted = false;
        
    }
    public BaseEntity(User createdByUser)
    {
        CreatedByUser = createdByUser;
        CreatedBy = createdByUser.Id;
        UpdatedBy = createdByUser.Id;
        UpdatedByUser = createdByUser;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsDeleted = false;
    }
}