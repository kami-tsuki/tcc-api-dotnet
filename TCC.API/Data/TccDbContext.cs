using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using TCC.API.models.authentication;
using TCC.API.Services;

namespace TCC.API.Data;

public class TccDbContext(DbContextOptions<TccDbContext> options, IEncryptionService encryptionService) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var guestRole = new Role { Id = 1, Name = "Guest" };
        modelBuilder.Entity<Role>().HasData(guestRole);
        
        modelBuilder.Entity<User>()
                    .Property(u => u.RoleId)
                    .HasDefaultValue(guestRole.Id);

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