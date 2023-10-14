
namespace Domain.Entities;

public class Rol : BaseEntity
{
    public string Nombre { get; set; }

    //Collections
    public ICollection<Usuario> Usuarios { get; set; }
    public ICollection<RolUsuario> RolesUsuarios { get; set; }

}
