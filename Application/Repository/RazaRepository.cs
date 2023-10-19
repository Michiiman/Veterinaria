
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

    public async Task<Object> MascotasPorRaza()
    {
        var dato = from r in _context.Razas
                select new
                {
                    Nombre = r.Nombre,
                    Mascotas = (from m in _context.Mascotas
                                where m.RazaIdFk == r.Id
                                select new
                                {
                                    Nombre = m.Nombre,
                                    Especie = m.Raza.Especie.Nombre
                                }).ToList()
                };

        var Resultado = await dato.ToListAsync();
        return Resultado;
    }
    
}

