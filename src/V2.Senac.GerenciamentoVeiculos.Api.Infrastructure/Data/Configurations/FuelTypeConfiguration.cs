using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V2.Senac.GerenciamentoVeiculos.Api.Domain.Entities;

namespace V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Data.Configurations;

public class FuelTypeConfiguration : IEntityTypeConfiguration<FuelTypeEntity>
{
    public void Configure(EntityTypeBuilder<FuelTypeEntity> builder)
    {
        builder.ToTable("fuel_types");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(f => f.Name)
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();

        // Add unique constraint on name
        builder.HasIndex(f => f.Name)
            .IsUnique();
    }
}
