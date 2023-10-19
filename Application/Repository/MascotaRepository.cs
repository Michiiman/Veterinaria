
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
        .Include(p => p.Raza).ThenInclude(p => p.Especie)
        .Include(p => p.Propietario)
        .ToListAsync();
    }

    public override async Task<Mascota> GetByIdAsync(int id)
    {
        return await _context.Mascotas
        .Include(p => p.Raza)
        .Include(p => p.Propietario)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    //Endpoints

    public async Task<IEnumerable<object>> MascotasFelinas()
    {
        var mascotas = await (
            from m in _context.Mascotas
            join e in _context.Especies on m.RazaIdFk equals e.Id
            where m.Raza.EspecieIdFk == 1
            select new
            {
                Nombre = m.Nombre,
                Especie = e.Nombre,
                Propietario = m.Propietario.Nombre
            }
        ).ToListAsync();

        return mascotas;
    }

    public async Task<object> MascotasPorEspecie()
    {
        var consulta =
        from e in _context.Especies
        select new
        {
            Especie = e.Nombre,
            Mascotas = (from mas in _context.Mascotas
                        join r in _context.Razas on mas.RazaIdFk equals r.Id
                        where mas.RazaIdFk == r.Id
                        where r.EspecieIdFk == e.Id
                        select new
                        {
                            Nombre = mas.Nombre,
                            Raza = r.Nombre
                        }).ToList()
        };

        var MasEspecie = await consulta.ToListAsync();
        return MasEspecie;

    }

    public async Task<IEnumerable<object>> MascotasVacunadas()
    {
        int año = 2023;
        DateOnly trimestreInicio = new DateOnly(año, 1, 1);
        DateOnly trimestreFinal = new DateOnly(año, 3, 31);

        var mascotas = await (
                        from c in _context.Citas
                        join m in _context.Mascotas on c.MascotaIdFk equals m.Id
                        where c.Motivo == "Vacunacion" && c.Fecha >= trimestreInicio && c.Fecha <= trimestreFinal
                        select new
                        {
                            Nombre=m.Nombre,
                            Motivo=c.Motivo,
                            FechaCita=c.Fecha,
                            Veterinario=c.Veterinario.Nombre
                        }).Distinct()
                        .ToListAsync();
        return mascotas;
    }

    public async Task<IEnumerable<object>> MascotasPorVeterinario()
    {

        var mascotas = await (
                        from c in _context.Citas
                        join v in _context.Veterinarios on c.VeterinarioIdFk equals v.Id
                        where c.VeterinarioIdFk == 1
                        select new
                        {
                            Nombre=c.Mascota.Nombre,
                            Propietario=c.Mascota.Propietario.Nombre,
                            FechaCita=c.Fecha,
                            Veterinario=v.Nombre
                        }).Distinct()
                        .ToListAsync();
        return mascotas;
    }

    public async Task<IEnumerable<object>> MascotasGoldenRetriever()
    {

        var mascotas = await (
                        from m in _context.Mascotas
                        join r in _context.Razas on m.RazaIdFk equals r.Id
                        where m.Raza.Nombre == "Golden Retriever"
                        select new
                        {
                            Nombre=m.Nombre,
                            Propietario=m.Propietario.Nombre,
            
                        }).ToListAsync();
        return mascotas;
    }


}