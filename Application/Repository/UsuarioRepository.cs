
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    protected readonly ApiVetContext _context;

    public UsuarioRepository(ApiVetContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios
        .Include(p=>p.Roles)
        .ToListAsync();
    }

    public override async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Usuarios
        .Include(p=>p.Roles)        
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}

