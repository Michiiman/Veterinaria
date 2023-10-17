
namespace Domain.Entities;

public class Mascota : BaseEntity
{
    public int PropietarioIdFk { get; set; }
    public Propietario Propietario { get; set; }
    public int RazaIdFk { get; set; }
    public Raza Raza { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaNacimiento { get; set; }

    //Collections
    public ICollection<Cita> Citas { get; set; }
    
}
