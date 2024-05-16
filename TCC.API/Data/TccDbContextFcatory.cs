namespace TCC.API.Data;

public class TccDbContextFactory : IDesignTimeDbContextFactory<TccDbContext>
{
    public TccDbContext CreateDbContext(params string[]? args)
    {
        var configuration = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json")
                           .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TccDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new(optionsBuilder.Options, new EncryptionService(configuration));
    }
}