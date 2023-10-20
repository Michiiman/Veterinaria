
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class PropietarioRepository : GenericRepository<Propietario>,IPropietario
{
    protected readonly ApiVetContext _context;

    public PropietarioRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Propietario>> GetAllAsync()
    {
        return await _context.Propietarios
        .ToListAsync();
    }

    public override async Task<Propietario> GetByIdAsync(int id)
    {
        return await _context.Propietarios
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Propietario> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Propietarios as IQueryable<Propietario>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    //EndPoints

    public async Task<object> PropietariosMascotas()
    {
        var dato = from p in _context.Propietarios
        select new
        {
            Nombre=p.Nombre,
            Mascotas=( from m in _context.Mascotas
                        where m.PropietarioIdFk==p.Id
                        select new
                        {
                            Nombre=m.Nombre,
                            Especie=m.Raza.Especie.Nombre
                        }).ToList()
        };

        var Resultado = await dato.ToListAsync();
        return Resultado;
    }

    public virtual async Task<(int totalRegistros, object registros)> PropietariosMascotas(int pageIndez, int pageSize, string search)
    {
        var query = from p in _context.Propietarios
        select new
        {
            Nombre=p.Nombre,
            Mascotas=( from m in _context.Mascotas
                        where m.PropietarioIdFk==p.Id
                        select new
                        {
                            Nombre=m.Nombre,
                            Especie=m.Raza.Especie.Nombre
                        }).ToList()
        };

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Nombre);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }



    
}

