using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V2.Senac.GerenciamentoVeiculos.Api.Domain.Entities;

namespace V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Data.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        // Map to the lowercase table name to match your database
        builder.ToTable("cars");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(c => c.Model)
            .HasColumnName("model")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Brand)
            .HasColumnName("brand")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.Color)
            .HasColumnName("color")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(c => c.Plate)
            .HasColumnName("plate")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(c => c.Year)
            .HasColumnName("year")
            .IsRequired();

        builder.Property(c => c.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(12,2)")
            .IsRequired();

        builder.Property(c => c.FuelTypeId)
            .HasColumnName("fuel_type_id")
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        // Configure foreign key relationship
        builder.HasOne(c => c.FuelTypeEntity)
            .WithMany(f => f.Cars)
            .HasForeignKey(c => c.FuelTypeId)
            .HasConstraintName("fk_cars_fuel_type");

        // Add indexes to match your database
        builder.HasIndex(c => c.Plate)
            .IsUnique()
            .HasDatabaseName("idx_cars_plate");

        builder.HasIndex(c => c.Brand)
            .HasDatabaseName("idx_cars_brand");

        builder.HasIndex(c => c.Year)
            .HasDatabaseName("idx_cars_year");

        builder.HasIndex(c => c.FuelTypeId)
            .HasDatabaseName("idx_cars_fuel_type");

        builder.HasIndex(c => c.Price)
            .HasDatabaseName("idx_cars_price");
    }
}
