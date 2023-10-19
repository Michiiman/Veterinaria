

using Domain.Entities;

namespace Domain.Interfaces;

public interface IMovimientoMedicamento : IGenericRepository<MovimientoMedicamento>
{
    Task<IEnumerable<Object>> TotalMovimientos();
}
