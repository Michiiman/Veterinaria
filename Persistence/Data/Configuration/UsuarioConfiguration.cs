using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("user");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.Nombre)
        .HasColumnName("Username")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Password)
        .HasColumnName("Password")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(255);

        builder.Property(e => e.Email)
        .HasColumnName("Email")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(150);

        builder
            .HasMany(p=>p.Roles)
            .WithMany(p=>p.Usuarios)
            .UsingEntity<RolUsuario>(
            j=>j
                .HasOne(pt=>pt.Rol)
                .WithMany(t=>t.RolesUsuarios)
                .HasForeignKey(pt=>pt.RolIdFk),
            j => j
                .HasOne(pt => pt.Usuario)
                .WithMany(t => t.RolesUsuarios)
                .HasForeignKey(pt => pt.UsuarioIdFk),
            j => 
            {
                j.ToTable("userRol");
                j.HasKey(t => new { t.UsuarioIdFk, t.RolIdFk});
            });
    }
}
