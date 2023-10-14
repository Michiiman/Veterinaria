
namespace Domain.Entities;

public class Proveedor : BaseEntity
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }

    //Collections
    public ICollection<MedicamentoProveedor> MedicamentosProveedores { get; set; }
    public ICollection<Medicamento> Medicamentos { get; set; }

}
