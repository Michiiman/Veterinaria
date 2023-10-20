
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
    public override async Task<(int totalRegistros, IEnumerable<Laboratorio> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Laboratorios as IQueryable<Laboratorio>;

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