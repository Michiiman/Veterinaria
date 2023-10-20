
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class TratamientoMedicoRepository : GenericRepository<TratamientoMedico>, ITratamientoMedico
{
    protected readonly ApiVetContext _context;

    public TratamientoMedicoRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TratamientoMedico>> GetAllAsync()
    {
        return await _context.TratamientosMedicos
        .Include(p=>p.Cita)
        .Include(p=>p.Medicamento)
        .ToListAsync();
    }

    public override async Task<TratamientoMedico> GetByIdAsync(int id)
    {
        return await _context.TratamientosMedicos
        .Include(p=>p.Cita)
        .Include(p=>p.Medicamento)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<TratamientoMedico> registros)> GetAllAsync(int pageIndex, int pageSize, int search)
    {
        var query = _context.TratamientosMedicos as IQueryable<TratamientoMedico>;

        if (search != 0)
        {
            query = query.Where(p => p.CitaIdFk == search);
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(p => p.Cita)
            .Include(p => p.Medicamento)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    
}

