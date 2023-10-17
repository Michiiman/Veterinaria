
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorio
{
    protected readonly ApiVetContext _context;

    public LaboratorioRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Laboratorio>> GetAllAsync()
    {
        return await _context.Laboratorios        
        .ToListAsync();
    }

    public override async Task<Laboratorio> GetByIdAsync(int id)
    {
        return await _context.Laboratorios
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}