

using Domain.Entities;

namespace Domain.Interfaces;

public interface IVeterinario : IGenericRepository<Veterinario>
{
    Task<IEnumerable<object>> VetCirujanos();

}
