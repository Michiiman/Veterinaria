
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class DetalleMovimientoRepository : GenericRepository<DetalleMovimiento>, IDetalleMovimiento
{
    protected readonly ApiVetContext _context;

    public DetalleMovimientoRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleMovimiento>> GetAllAsync()
    {
        return await _context.DetallesMovimientos
        .Include(p => p.Medicamento)
        .Include(p => p.MovimientoMedicamento)
        .ToListAsync();
    }

    public override async Task<DetalleMovimiento> GetByIdAsync(int id)
    {
        return await _context.DetallesMovimientos
        .Include(p => p.Medicamento)
        .Include(p => p.MovimientoMedicamento)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}





