

namespace Domain.Entities;

public class Especie : BaseEntity
{
    public string Nombre { get; set; }

    //Collections
    public ICollection<Raza> Razas { get; set; }
}
