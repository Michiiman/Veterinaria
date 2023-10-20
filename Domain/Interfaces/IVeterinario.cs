

using Domain.Entities;

namespace Domain.Interfaces;

public interface IVeterinario : IGenericRepository<Veterinario>
{
    Task<IEnumerable<object>> VetCirujanos();
    Task<(int totalRegistros, object registros)> VetCirujanos(int pageIndez, int pageSize, string search);

}
