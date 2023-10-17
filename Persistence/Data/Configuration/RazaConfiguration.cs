using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class RazaConfiguration : IEntityTypeConfiguration<Raza>
    {
        public void Configure(EntityTypeBuilder<Raza> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("raza");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(30);

            builder.HasOne(p => p.Especie)
            .WithMany(p => p.Razas)
            .HasForeignKey(p => p.EspecieIdFk);
            
        }
    }
}