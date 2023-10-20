

using Domain.Entities;

namespace Domain.Interfaces;

public interface IPropietario : IGenericRepository<Propietario>
{
    Task<Object> PropietariosMascotas();
    Task<(int totalRegistros, object registros)> PropietariosMascotas(int pageIndez, int pageSize, string search);
}
