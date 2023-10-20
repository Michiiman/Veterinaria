
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class CitaRepository : GenericRepository<Cita>, ICita
{
    protected readonly ApiVetContext _context;

    public CitaRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _context.Citas
        .Include(p => p.Mascota).ThenInclude(p => p.Propietario)
        .Include(p => p.Mascota).ThenInclude(p => p.Raza).ThenInclude(p=>p.Especie)        
        .Include(p => p.Veterinario)
        .ToListAsync();
    }

    public override async Task<Cita> GetByIdAsync(int id)
    {
        return await _context.Citas
        .Include(p => p.Mascota).ThenInclude(p => p.Propietario)
        .Include(p => p.Mascota).ThenInclude(p => p.Raza).ThenInclude(p=>p.Especie)
        .Include(p => p.Veterinario)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
     public override async Task<(int totalRegistros, IEnumerable<Cita> registros)> GetAllAsync(int pageIndex, int pageSize, int search)
    {
        var query = _context.Citas as IQueryable<Cita>;

        if (search != 0)
        {
            query = query.Where(p => p.VeterinarioIdFk == search);
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(p => p.Mascota).ThenInclude(p => p.Propietario)
            .Include(p => p.Mascota).ThenInclude(p => p.Raza).ThenInclude(p=>p.Especie)        
            .Include(p => p.Veterinario)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}