
using Domain.Entities;

namespace Domain.Interfaces;

public interface IProveedor: IGenericRepository<Proveedor>
{
    Task<object> ProveedoresMedicamentos();
    Task<(int totalRegistros, object registros)> ProveedoresMedicamentos(int pageIndez, int pageSize, string search);

}
