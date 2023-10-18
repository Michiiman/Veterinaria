
namespace ApiVet.Dtos;

public class CitaDto
{
    public int Id{get;set;}
    public int MascotaIdFk{get;set;}
    public MascotaDto Mascota{get;set;}
    public DateOnly Fecha{get;set;}
    public TimeOnly Hora{get;set;}
    public string Motivo{get;set;}
    public int VeterinarioIdFk{get;set;}
    public VeterinarioDto Veterinario{get;set;}

}
