
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class CitaRepository : GenericRepository<Cita>,ICita
{
    protected readonly ApiVetContext _context;

    public CitaRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _context.Citas
        .Include(p => p.Mascota)
        .ToListAsync();
    }

    public override async Task<Cita> GetByIdAsync(int id)
    {
        return await _context.Citas
            .Include(p => p.Mascota)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}