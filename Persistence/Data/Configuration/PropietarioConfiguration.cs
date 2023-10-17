using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>
    {
        public void Configure(EntityTypeBuilder<Propietario> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("propietario");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Telefono)
            .HasMaxLength(30);

        }
    }
}