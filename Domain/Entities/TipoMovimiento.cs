

namespace Domain.Entities;

public class TipoMovimiento : BaseEntity
{
    public string Descripcion { get; set; }

    //Collections
    public ICollection<MovimientoMedicamento> MovimientosMedicamentos { get; set; }
    
}
