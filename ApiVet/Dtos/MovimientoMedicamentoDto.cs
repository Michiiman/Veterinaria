
namespace ApiVet.Dtos;

public class MovimientoMedicamentoDto
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public DateOnly Fecha { get; set; }
    public int TipoMovimientoIdFk { get; set; }
    public TipoMovimientoDto TipoMovimiento { get; set; }

}
