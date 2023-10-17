
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class RazaRepository : GenericRepository<Raza>, IRaza
{
    protected readonly ApiVetContext _context;

    public RazaRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Raza>> GetAllAsync()
    {
        return await _context.Razas
        .Include(p => p.Especie)
        .ToListAsync();
    }

    public override async Task<Raza> GetByIdAsync(int id)
    {
        return await _context.Razas
        .Include(p => p.Especie)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}

