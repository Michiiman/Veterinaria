

using Domain.Entities;

namespace Domain.Interfaces;

public interface IMovimientoMedicamento : IGenericRepository<MovimientoMedicamento>
{
    Task<IEnumerable<Object>> TotalMovimientos();
    Task<(int totalRegistros, object registros)> TotalMovimientos(int pageIndez, int pageSize, string search);
}
