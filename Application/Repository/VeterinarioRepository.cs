
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
}

