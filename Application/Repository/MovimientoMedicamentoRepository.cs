
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
}

