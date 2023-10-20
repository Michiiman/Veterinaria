
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class MedicamentoRepository : GenericRepository<Medicamento>,IMedicamento
{
    protected readonly ApiVetContext _context;

    public MedicamentoRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos
        .Include(p => p.Laboratorio)
        .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Medicamentos
        .Include(p => p.Laboratorio)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Medicamentos as IQueryable<Medicamento>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Include(p => p.Laboratorio)
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    public async Task<IEnumerable<object>> MedGenfar()
    {
        var medicamentos= await (
            from med in _context.Medicamentos
            where med.LaboratorioIdFk == 1
            select new 
            {
                Nombre=med.Nombre,
                Laboratorio=med.Laboratorio.Nombre,
                Cantidad=med.CantidadDisponible
            }
        ).ToListAsync();

        return medicamentos;
    }

    public virtual async Task<(int totalRegistros, object registros)> MedGenfar(int pageIndez, int pageSize, string search)
    {
        var query = (
            from med in _context.Medicamentos
            where med.LaboratorioIdFk == 1
            select new 
            {
                Nombre=med.Nombre,
                Laboratorio=med.Laboratorio.Nombre,
                Cantidad=med.CantidadDisponible
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

    public async Task<IEnumerable<object>> MedMayor50k()
    {
        var Medicamento =  await(from m in _context.Medicamentos
                                where m.Precio>50000
                                select new
                                {
                                    Nombre=m.Nombre,
                                    CantidadDisponible=m.CantidadDisponible,
                                    Precio=m.Precio
                                }).ToListAsync();
        return Medicamento;
    }

    public virtual async Task<(int totalRegistros, object registros)> MedMayor50k(int pageIndez, int pageSize, string search)
    {
        var query = (from m in _context.Medicamentos
                                where m.Precio>50000
                                select new
                                {
                                    Nombre=m.Nombre,
                                    CantidadDisponible=m.CantidadDisponible,
                                    Precio=m.Precio
                                });

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





    