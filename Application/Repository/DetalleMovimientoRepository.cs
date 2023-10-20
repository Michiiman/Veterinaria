
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
    public override async Task<(int totalRegistros, IEnumerable<DetalleMovimiento> registros)> GetAllAsync(int pageIndex, int pageSize, int search)
    {
        var query = _context.DetallesMovimientos as IQueryable<DetalleMovimiento>;

        if (search != 0)
        {
            query = query.Where(p => p.MovimientoMedicamentoIdFk == search);
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(p => p.MovimientoMedicamento)
            .Include(p => p.Medicamento)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}





