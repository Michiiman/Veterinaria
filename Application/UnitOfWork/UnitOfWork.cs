
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiVetContext context;

    private MedicamentoRepository _medicamento;
    private CitaRepository _cita;
    private DetalleMovimientoRepository _detalleMovimiento;
    private EspecieRepository _especie;
    private LaboratorioRepository _laboratorio;
    private MascotaRepository _mascota;
    private MovimientoMedicamentoRepository _movimientoMedicamento;
    private PropietarioRepository _propietario;
    private ProveedorRepository _proveedor;
    private RazaRepository _raza;
    private TipoMovimientoRepository _tipoMovimiento;
    private TratamientoMedicoRepository _tratamientoMedico;
    private VeterinarioRepository _veterinario;
    private UsuarioRepository usuario;
    private RolRepository rols;

    public UnitOfWork(ApiVetContext _context)
    {
        context = _context;
    }

    public IMedicamento Medicamentos
    {
        get
        {
            if (_medicamento == null)
            {
                _medicamento = new MedicamentoRepository(context);
            }
            return _medicamento;
        }
    }

    public ICita Citas
    {
        get
        {
            if (_cita == null)
            {
                _cita = new CitaRepository(context);
            }
            return _cita;
        }
    }

    public IDetalleMovimiento DetallesMovimientos
    {
        get
        {
            if (_detalleMovimiento == null)
            {
                _detalleMovimiento = new DetalleMovimientoRepository(context);
            }
            return _detalleMovimiento;
        }
    }




    public int Save()
    {
        return context.SaveChanges();
    }
    public void Dispose()
    {
        context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}