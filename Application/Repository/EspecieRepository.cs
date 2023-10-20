
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class EspecieRepository : GenericRepository<Especie>, IEspecie
{
    protected readonly ApiVetContext _context;

    public EspecieRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Especie>> GetAllAsync()
    {
        return await _context.Especies        
        .ToListAsync();
    }

    public override async Task<Especie> GetByIdAsync(int id)
    {
        return await _context.Especies
        .FirstOrDefaultAsync(p => p.Id == id);
    }

     public override async Task<(int totalRegistros, IEnumerable<Especie> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Especies as IQueryable<Especie>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();


        return (totalRegistros, registros);
    }
}