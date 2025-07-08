using Microsoft.EntityFrameworkCore;
using V2.Senac.GerenciamentoVeiculos.Api.Domain.Entities;
using System.Collections.Generic;

namespace V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Data;

/// <summary>
/// Application database context
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Add DbSets here for your entities
    public DbSet<Car> Cars { get; set; }
    public DbSet<FuelTypeEntity> FuelTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply entity configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Configure Car entity
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Model).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Brand).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Plate).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Year).IsRequired();
            entity.Property(e => e.FuelTypeId).IsRequired();

            // Configure foreign key relationship
            entity.HasOne(e => e.FuelTypeEntity)
                  .WithMany(f => f.Cars)
                  .HasForeignKey(e => e.FuelTypeId);
        });
    }
}
