

namespace Domain.Entities;

public class TipoMovimiento
{
    public string Nombre { get; set; }

    //Collections
    public ICollection<MovimientoMedicamento> MovimientosMedicamentos { get; set; }
    
}
