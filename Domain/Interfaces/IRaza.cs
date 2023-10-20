

using Domain.Entities;

namespace Domain.Interfaces;

public interface IRaza : IGenericRepository<Raza>
{
    Task<Object> MascotasPorRaza();
    Task<(int totalRegistros, object registros)> MascotasPorRaza(int pageIndez, int pageSize, string search);

}
