

using Domain.Entities;

namespace Domain.Interfaces;

public interface IMedicamento : IGenericRepository<Medicamento>
{
    Task<IEnumerable<object>> MedGenfar();
    Task<(int totalRegistros, object registros)> MedGenfar(int pageIndez, int pageSize, string search);
    Task<IEnumerable<object>> MedMayor50k();
    Task<(int totalRegistros, object registros)> MedMayor50k(int pageIndez, int pageSize, string search);
    
}
