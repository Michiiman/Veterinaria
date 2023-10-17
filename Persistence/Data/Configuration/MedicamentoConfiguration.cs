using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("medicamento");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(60);

            builder.Property(p => p.CantidadDisponible)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(p => p.Precio)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(p => p.Laboratorio)
            .WithMany(p => p.Medicamentos)
            .HasForeignKey(p => p.LaboratorioIdFk);

            builder
            .HasMany(p => p.Proveedores)
            .WithMany(p => p.Medicamentos)
            .UsingEntity<MedicamentoProveedor>(
            j => j
            .HasOne(pt => pt.Proveedor)
            .WithMany(t => t.MedicamentosProveedores)
            .HasForeignKey(pt => pt.ProveedorIdFk),
            j => j
            .HasOne(pt => pt.Medicamento)
            .WithMany(t => t.MedicamentosProveedores)
            .HasForeignKey(pt => pt.MedicamentoIdFk),
            j =>
            {
                j.ToTable("medicamentosProveedor");
                j.HasKey(t => new { t.ProveedorIdFk, t.MedicamentoIdFk });
            });


        }
    }
}