
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
}

