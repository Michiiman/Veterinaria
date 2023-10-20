
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinario
{
    protected readonly ApiVetContext _context;

    public VeterinarioRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Veterinario>> GetAllAsync()
    {
        return await _context.Veterinarios
        .ToListAsync();
    }

    public override async Task<Veterinario> GetByIdAsync(int id)
    {
        return await _context.Veterinarios

        .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public override async Task<(int totalRegistros, IEnumerable<Veterinario> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Veterinarios as IQueryable<Veterinario>;

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
    public async Task<IEnumerable<object>> VetCirujanos()
    {
        var veterinarios= await (
            from vet in _context.Veterinarios
            where vet.Especialidad=="Cirujano Vascular"
            select new 
            {
                Nombre=vet.Nombre,
                Especialidad=vet.Especialidad
            }
        ).ToListAsync();

        return veterinarios;
    }
    
    public virtual async Task<(int totalRegistros, object registros)> VetCirujanos(int pageIndez, int pageSize, string search)
    {
        var query = (from vet in _context.Veterinarios
            where vet.Especialidad=="Cirujano Vascular"
            select new 
            {
                Nombre=vet.Nombre,
                Especialidad=vet.Especialidad
            }
        );

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Nombre);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}

