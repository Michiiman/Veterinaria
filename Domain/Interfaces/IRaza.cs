

using Domain.Entities;

namespace Domain.Interfaces;

public interface IRaza : IGenericRepository<Raza>
{
    Task<Object> MascotasPorRaza();

}
