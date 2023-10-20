
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class TipoMovimientoRepository : GenericRepository<TipoMovimiento>, ITipoMovimiento
{
    protected readonly ApiVetContext _context;

    public TipoMovimientoRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoMovimiento>> GetAllAsync()
    {
        return await _context.TiposMovimientos
        .ToListAsync();
    }

    public override async Task<TipoMovimiento> GetByIdAsync(int id)
    {
        return await _context.TiposMovimientos
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<TipoMovimiento> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.TiposMovimientos as IQueryable<TipoMovimiento>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Descripcion.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}

