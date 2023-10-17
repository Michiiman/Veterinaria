using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
    {
        public void Configure(EntityTypeBuilder<Veterinario> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("veterinario");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(p => p.Email)
            .HasMaxLength(30);

            builder.Property(p => p.Telefono)
            .HasMaxLength(30);

            builder.Property(p => p.Especialidad)
            .HasMaxLength(30);
            
        }
    }
}