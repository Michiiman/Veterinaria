
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
    private UsuarioRepository _usuario;
    private RolRepository _rol;

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
    public IEspecie Especies
    {
        get
        {
            if (_especie == null)
            {
                _especie = new EspecieRepository(context);
            }
            return _especie;
        }
    }
    public ILaboratorio Laboratorios
    {
        get
        {
            if (_laboratorio == null)
            {
                _laboratorio = new LaboratorioRepository(context);
            }
            return _laboratorio;
        }
    }
    public IMascota Mascotas
    {
        get
        {
            if (_mascota == null)
            {
                _mascota = new MascotaRepository(context);
            }
            return _mascota;
        }
    }
    public IMovimientoMedicamento MovimientosMedicamentos
    {
        get
        {
            if (_movimientoMedicamento == null)
            {
                _movimientoMedicamento = new MovimientoMedicamentoRepository(context);
            }
            return _movimientoMedicamento;
        }
    }
    public IPropietario Propietarios
    {
        get
        {
            if (_propietario == null)
            {
                _propietario = new PropietarioRepository(context);
            }
            return _propietario;
        }
    }
    public IProveedor Proveedores
    {
        get
        {
            if (_proveedor == null)
            {
                _proveedor = new ProveedorRepository(context);
            }
            return _proveedor;
        }
    }
    public IRaza Razas
    {
        get
        {
            if (_raza == null)
            {
                _raza = new RazaRepository(context);
            }
            return _raza;
        }
    }
    public IRol Roles
    {
        get
        {
            if (_rol == null)
            {
                _rol = new RolRepository(context);
            }
            return _rol;
        }
    }
    public ITipoMovimiento TiposMovimientos
    {
        get
        {
            if (_tipoMovimiento == null)
            {
                _tipoMovimiento = new TipoMovimientoRepository(context);
            }
            return _tipoMovimiento;
        }
    }
    public ITratamientoMedico TratamientosMedicos
    {
        get
        {
            if (_tratamientoMedico == null)
            {
                _tratamientoMedico = new TratamientoMedicoRepository(context);
            }
            return _tratamientoMedico;
        }
    }
    public IUsuario Usuarios
    {
        get
        {
            if (_usuario == null)
            {
                _usuario = new UsuarioRepository(context);
            }
            return _usuario;
        }
    }
    public IVeterinario Veterinarios
    {
        get
        {
            if (_veterinario == null)
            {
                _veterinario = new VeterinarioRepository(context);
            }
            return _veterinario;
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