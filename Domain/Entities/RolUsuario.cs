
namespace Domain.Entities;

public class RolUsuario
{
    public int UsuarioIdFk { get; set; }
    public Usuario Usuario { get; set; }
    public int RolIdFk { get; set; }
    public Rol Rol { get; set; }
}
