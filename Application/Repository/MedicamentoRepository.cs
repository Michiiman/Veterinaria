
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class MedicamentoRepository : GenericRepository<Medicamento>,IMedicamento
{
    protected readonly ApiVetContext _context;

    public MedicamentoRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos
        .Include(p => p.Laboratorio)
        .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Medicamentos
        .Include(p => p.Laboratorio)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}





    