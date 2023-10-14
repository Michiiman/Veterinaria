

namespace Domain.Entities;

public class TratamientoMedico : BaseEntity
{
    public int CitaIdFk { get; set; }
    public Cita Cita { get; set; }
    public int MedicamentoIdFk { get; set; }
    public Medicamento Medicamento { get; set; }
    public string Dosis { get; set; }
    public DateOnly FechaAdministracion { get; set; }
    public string Observacion { get; set; }


}
