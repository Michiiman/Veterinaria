
namespace Domain.Entities;

public class Usuario : BaseEntity
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Constraseña { get; set; }

    //Collections
    public ICollection<Rol>Roles{get;set;}
    public ICollection<RolUsuario> RolesUsuarios { get; set; }

}
