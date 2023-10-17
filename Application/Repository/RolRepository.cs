
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class RolRepository : GenericRepository<Rol>, IRol
{
    protected readonly ApiVetContext _context;

    public RolRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Rol>> GetAllAsync()
    {
        return await _context.Roles
        .Include(p => p.Usuarios)
        .ToListAsync();
    }

    public override async Task<Rol> GetByIdAsync(int id)
    {
        return await _context.Roles
        .Include(p => p.Usuarios)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}

