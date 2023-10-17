using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimiento>
    {
        public void Configure(EntityTypeBuilder<TipoMovimiento> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("tipoMovimiento");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Descripcion)
            .IsRequired()
            .HasMaxLength(255);
            
        }
    }
}