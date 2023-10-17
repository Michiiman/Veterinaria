using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("rol");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.Nombre)
        .HasColumnName("Nombre")
        .IsRequired()
        .HasMaxLength(50);
    }
}