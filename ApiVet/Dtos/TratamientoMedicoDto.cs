

namespace ApiVet.Dtos;

public class TratamientoMedicoDto
{
    public int Id { get; set; }
    public int CitaIdFk { get; set; }
    public CitaDto Cita { get; set; }
    public int MedicamentoIdFk { get; set; }
    public MedicamentoDto Medicamento { get; set; }
    public string Dosis { get; set; }
    public DateOnly FechaAdministracion { get; set; }
    public string Observacion { get; set; }

}
