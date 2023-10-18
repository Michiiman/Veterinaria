

namespace ApiVet.Dtos;

public class MascotaDto
{
    public int Id { get; set; }
    public int PropietarioIdFk { get; set; }
    public PropietarioDto Propietario { get; set; }
    public int RazaIdFk { get; set; }
    public RazaDto Raza { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaNacimiento { get; set; }

}
