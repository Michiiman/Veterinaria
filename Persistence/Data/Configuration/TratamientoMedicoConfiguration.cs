using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
    {
        public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("tratamientoMedico");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Dosis)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(p => p.FechaAdministracion)
            .IsRequired()
            .HasColumnType("date")
            .HasMaxLength(30);

            builder.Property(p => p.Observacion)
            .IsRequired()
            .HasMaxLength(255);

            builder.HasOne(p => p.Medicamento)
            .WithMany(p => p.TratamientosMedicos)
            .HasForeignKey(p => p.MedicamentoIdFk);

            builder.HasOne(p => p.Cita)
            .WithMany(p => p.TratamientosMedicos)
            .HasForeignKey(p => p.CitaIdFk);

            

        }
    }
}