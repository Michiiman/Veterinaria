
namespace Domain.Entities;

public class Propietario : BaseEntity
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    //Collections
    public ICollection<Mascota> Mascotas { get; set; }
}
