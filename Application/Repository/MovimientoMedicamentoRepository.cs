
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class MovimientoMedicamentoRepository : GenericRepository<MovimientoMedicamento>,IMovimientoMedicamento
{
    protected readonly ApiVetContext _context;

    public MovimientoMedicamentoRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoMedicamento>> GetAllAsync()
    {
        return await _context.MovimientosMedicamentos
        .Include(p => p.TipoMovimiento)
        .ToListAsync();
    }

    public override async Task<MovimientoMedicamento> GetByIdAsync(int id)
    {
        return await _context.MovimientosMedicamentos
        .Include(p => p.TipoMovimiento)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}

