using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DetallleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
    {
        public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("detalleMovimiento");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Cantidad)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Precio)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.MovimientoMedicamento)
            .WithMany(p => p.DetallesMovimientos)
            .HasForeignKey(p => p.MovimientoMedicamentoIdFk);

            builder.HasOne(p => p.Medicamento)
            .WithMany(p => p.DetallesMovimientos)
            .HasForeignKey(p => p.MedicamentoIdFk);
        }
    }
}