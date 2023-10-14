
namespace Domain.Entities;

public class MedicamentoProveedor
{
    public int MedicamentoIdFk { get; set; }
    public Medicamento Medicamento { get; set; }
    public int ProveedorIdFk { get; set; }
    public Proveedor Proveedor { get; set; }

}
