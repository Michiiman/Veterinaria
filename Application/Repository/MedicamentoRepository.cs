
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
}





    