namespace TCC.API.Data;

public class TccDbContext(DbContextOptions<TccDbContext> options, IEncryptionService encryptionService) : DbContext(options)
{
    public static readonly List<Role> DefaultRoles =
    [
        new() { Id = 1UL, Name = "Guest" },
        new() { Id = 10UL, Name = "User" },
        new() { Id = 20UL, Name = "Super-User" },
        new() { Id = 100UL, Name = "Moderator" },
        new() { Id = 1000UL, Name = "Admin" },
        new() { Id = 1001UL, Name = "App-Admin" },
        new() { Id = 1002UL, Name = "API-Admin" }
    ];

    public DbSet<User?> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Settings> Settings { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<TravelEntry> TravelEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var role in DefaultRoles) modelBuilder.Entity<Role>().HasData(role);


        modelBuilder.Entity<User>()
                    .Property(u => u.Password)
                    .HasConversion(
                         v => encryptionService.Encrypt(v),
                         v => v);

        modelBuilder.Entity<User>()
                    .HasIndex(u => u.Username)
                    .IsUnique();

        modelBuilder.Entity<User>()
                    .HasIndex(u => u.Email)
                    .IsUnique();

        modelBuilder.Entity<User>()
                    .Property(u => u.Username)
                    .HasConversion(
                         v => v.ToLower(),
                         v => v);

        modelBuilder.Entity<User>()
                    .Property(u => u.Email)
                    .HasConversion(
                         v => v.ToLower(),
                         v => v);

        modelBuilder.Entity<Role>()
                    .HasIndex(r => r.Name)
                    .IsUnique();
    }
}