
namespace ApiVet.Dtos;

public class RazaDto
{
    public int Id { get; set; }
    public int EspecieIdFk { get; set; }
    public EspecieDto Especie { get; set; }
    public string Nombre { get; set; }
}
