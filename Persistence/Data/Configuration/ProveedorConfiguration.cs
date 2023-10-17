using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("proveedor");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Direccion)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(p => p.Telefono)
            .HasMaxLength(30); 
            
        }
    }
}