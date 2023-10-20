
namespace Domain.Entities;

public class Usuario : BaseEntity
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    //Collections
    public ICollection<Rol>Roles{get;set;}
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    public ICollection<RolUsuario> RolesUsuarios { get; set; }

}
