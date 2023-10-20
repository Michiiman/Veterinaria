
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
    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Usuarios
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Nombre.ToLower() == username.ToLower());
    }
    public override async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios
        .Include(p => p.Roles)
        .ToListAsync();
    }

    public override async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Usuarios
        .Include(p => p.Roles)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Usuario> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Usuarios as IQueryable<Usuario>;

        if (!string.IsNullOrEmpty(search))
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
    public async Task<Usuario> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Usuarios
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }
    
}

