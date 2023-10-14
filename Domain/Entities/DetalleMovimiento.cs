

namespace Domain.Entities;

public class DetalleMovimiento : BaseEntity
{
    public int MedicamentoIdFk { get; set; }
    public Medicamento Medicamento { get; set; }
    public int Cantidad { get; set; }
    public int MovimientoMedicamentoIdFk { get; set; }
    public MovimientoMedicamento MovimientoMedicamento { get; set; }
    public int Precio { get; set; }

}
