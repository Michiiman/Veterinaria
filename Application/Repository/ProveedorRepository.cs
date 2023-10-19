
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ProveedorRepository : GenericRepository<Proveedor>,IProveedor
{
    protected readonly ApiVetContext _context;

    public ProveedorRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedores
        .ToListAsync();
    }

    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Proveedores
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<object> ProveedoresMedicamentos()
    {
        var consulta = from m in _context.Medicamentos
        select new
        {
            Nombre = m.Nombre,
            proveedores = (from mp in _context.MedicamentosProveedores
                        join me in _context.Medicamentos on mp.MedicamentoIdFk equals me.Id
                        join p in _context.Proveedores on mp.ProveedorIdFk equals p.Id
                        where m.Id == mp.MedicamentoIdFk
                        select new
                        {
                            NombreProveedor = p.Nombre,
                        }).ToList()
        };

        var propietariosConMascotas = await consulta.ToListAsync();
        return propietariosConMascotas;
    }
}

