
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
    public override async Task<(int totalRegistros, IEnumerable<MovimientoMedicamento> registros)> GetAllAsync(int pageIndex, int pageSize, int search)
    {
        var query = _context.MovimientosMedicamentos as IQueryable<MovimientoMedicamento>;

        if (search != 0)
        {
            query = query.Where(p => p.Id == search);
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(p => p.TipoMovimiento)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    //EndPoints

    public async Task<IEnumerable<Object>> TotalMovimientos()
    {
        var Total= await(from d in _context.DetallesMovimientos
                        join mm in _context.MovimientosMedicamentos on d.MovimientoMedicamentoIdFk equals mm.Id
                        select new
                        {
                            IdDetalleMovimiento = d.Id,
                            Medicamento=d.Medicamento.Nombre,
                            Total=d.Cantidad*d.Precio
                        }).Distinct()
                        .ToListAsync();
            return Total;
    }

    public virtual async Task<(int totalRegistros, object registros)> TotalMovimientos(int pageIndez, int pageSize, string search)
    {
        var query = (from d in _context.DetallesMovimientos
                        join mm in _context.MovimientosMedicamentos on d.MovimientoMedicamentoIdFk equals mm.Id
                        select new
                        {
                            IdDetalleMovimiento = d.Id,
                            Medicamento=d.Medicamento.Nombre,
                            Total=d.Cantidad*d.Precio
                        }).Distinct();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Medicamento.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Medicamento);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}

