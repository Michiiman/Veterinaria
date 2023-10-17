
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
}

