using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("mascota");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.FechaNacimiento)
            .IsRequired()
            .HasMaxLength(30);

            builder.HasOne(p => p.Propietario)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.PropietarioIdFk);

            builder.HasOne(p => p.Raza)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.RazaIdFk);

        }
    }
}