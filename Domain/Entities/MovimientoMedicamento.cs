
namespace Domain.Entities;

public class MovimientoMedicamento : BaseEntity
{
    public int Cantidad { get; set; }
    public DateOnly Fecha { get; set; }
    public int TipoMovimientoIdFk { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }

    //Collections

    public ICollection<DetalleMovimiento> DetallesMovimientos { get; set; }

}
