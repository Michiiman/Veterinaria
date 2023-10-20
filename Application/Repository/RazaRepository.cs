
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class RazaRepository : GenericRepository<Raza>, IRaza
{
    protected readonly ApiVetContext _context;

    public RazaRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Raza>> GetAllAsync()
    {
        return await _context.Razas
        .Include(p => p.Especie)
        .ToListAsync();
    }

    public override async Task<Raza> GetByIdAsync(int id)
    {
        return await _context.Razas
        .Include(p => p.Especie)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Object> MascotasPorRaza()
    {
        var dato = from r in _context.Razas
                select new
                {
                    Nombre = r.Nombre,
                    Mascotas = _context.Mascotas.Distinct().Count(m => m.RazaIdFk == r.Id)
                };

        var Resultado = await dato.ToListAsync();
        return Resultado;
    }
    public override async Task<(int totalRegistros, IEnumerable<Raza> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Razas as IQueryable<Raza>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Include(p => p.Especie)
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    public virtual async Task<(int totalRegistros, object registros)> MascotasPorRaza(int pageIndez, int pageSize, string search)
    {
        var query = (from r in _context.Razas
                select new
                {
                    Nombre = r.Nombre,
                    Mascotas = _context.Mascotas.Distinct().Count(m => m.RazaIdFk == r.Id)
                });

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

