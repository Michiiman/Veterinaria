using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
    {
        public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("movimientoMedicamento");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Cantidad)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(p => p.Fecha)
            .IsRequired()
            .HasColumnType("date")
            .HasMaxLength(30);

            builder.HasOne(p => p.TipoMovimiento)
            .WithMany(p => p.MovimientosMedicamentos)
            .HasForeignKey(p => p.TipoMovimientoIdFk);

        }
    }
}