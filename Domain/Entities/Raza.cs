
namespace Domain.Entities;

public class Raza : BaseEntity
{
    public int EspecieIdFk { get; set; }
    public Especie Especie { get; set; }
    public string Nombre { get; set; }

    //Collection 
    public ICollection<Mascota> Mascotas{get;set;}

}
