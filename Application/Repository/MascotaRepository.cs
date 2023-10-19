
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class MascotaRepository : GenericRepository<Mascota>, IMascota
{
    protected readonly ApiVetContext _context;

    public MascotaRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Mascota>> GetAllAsync()
    {
        return await _context.Mascotas
        .Include(p => p.Raza).ThenInclude(p=>p.Especie)
        .Include(p=>p.Propietario)
        .ToListAsync();
    }

    public override async Task<Mascota> GetByIdAsync(int id)
    {
        return await _context.Mascotas
        .Include(p => p.Raza)
        .Include(p=>p.Propietario)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    //Endpoints

    public async Task<IEnumerable<object>> MascotasFelinas()
    {
        var mascotas= await (
            from m in _context.Mascotas
            join e in _context.Especies on m.RazaIdFk equals e.Id
            where m.Raza.EspecieIdFk == 1
            select new 
            {
                Nombre=m.Nombre,
                Especie=e.Nombre,
                Propietario=m.Propietario.Nombre
            }
        ).ToListAsync();

        return mascotas;
    }
}