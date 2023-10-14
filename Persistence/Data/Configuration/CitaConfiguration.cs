using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CitaConfiguration : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("cita");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
            
            builder.Property(p => p.Hora)
            .IsRequired()
            .HasMaxLength(20);

            builder.Property(p => p.Motivo)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(p => p.Fecha)
            .HasColumnType("date")
            .IsRequired()
            .HasMaxLength(45);

            builder.HasOne(p => p.Mascota)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.MascotaIdFk);

            builder.HasOne(p => p.Veterinario)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.VeterinarioIdFk);

        }
    }
}