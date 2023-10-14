

namespace Domain.Entities;

public class Cita : BaseEntity
{
    public int MascotaIdFk { get; set; }
    public Mascota Mascota { get; set; }
    public DateOnly Fecha { get; set; }
    public TimeOnly Hora { get; set; }
    public string Motivo { get; set; }
    public int VeterinarioIdFk { get; set; }
    public Veterinario Veterinario { get; set; }

    //Collecctions
    public ICollection<TratamientoMedico> TratamientosMedicos { get; set; }


}
