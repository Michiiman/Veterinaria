

using Domain.Entities;

namespace Domain.Interfaces;

public interface IMascota : IGenericRepository<Mascota>
{
    Task<IEnumerable<object>> MascotasFelinas();
    Task<object> MascotasPorEspecie();
    Task<IEnumerable<object>> MascotasVacunadas();
    Task<IEnumerable<object>> MascotasPorVeterinario();
    Task<IEnumerable<object>> MascotasGoldenRetriever();
}
