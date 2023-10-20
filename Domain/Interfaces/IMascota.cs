

using Domain.Entities;

namespace Domain.Interfaces;

public interface IMascota : IGenericRepository<Mascota>
{
    Task<IEnumerable<object>> MascotasFelinas();
    Task<(int totalRegistros,object registros)> MascotasFelinas(int pageIndez, int pageSize, string search);
    Task<object> MascotasPorEspecie();
    Task<(int totalRegistros, object registros)> MascotasPorEspecie(int pageIndez, int pageSize, string search);
    Task<IEnumerable<object>> MascotasVacunadas();
    Task<(int totalRegistros, object registros)> MascotasVacunadas(int pageIndez, int pageSize, string search);
    Task<IEnumerable<object>> MascotasPorVeterinario();
    Task<(int totalRegistros, object registros)> MascotasPorVeterinario(int pageIndez, int pageSize, string search);
    Task<IEnumerable<object>> MascotasGoldenRetriever();
    Task<(int totalRegistros, object registros)> MascotasGoldenRetriever(int pageIndez, int pageSize, string search);
}
