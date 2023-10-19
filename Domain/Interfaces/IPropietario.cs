

using Domain.Entities;

namespace Domain.Interfaces;

public interface IPropietario : IGenericRepository<Propietario>
{
    Task<Object>PropietariosMascotas();
}
