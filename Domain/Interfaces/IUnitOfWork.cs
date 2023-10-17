
namespace Domain.Interfaces;

public interface IUnitOfWork
{
    //Se escriben en plural como se define en la unidad de trabajo
    IMedicamento Medicamentos { get; }
    ICita Citas { get; }
    IDetalleMovimiento DetallesMovimientos { get; }
    IEspecie Especies { get; }
    ILaboratorio Laboratorios { get; }
    IMascota Mascotas { get; }
    IMovimientoMedicamento MovimientosMedicamentos { get; }
    IPropietario Propietarios { get; }
    IProveedor Proveedores { get; }
    IRaza Razas { get; }
    ITipoMovimiento TiposMovimientos { get; }
    ITratamientoMedico TratamientosMedicos { get; }
    IVeterinario Veterinarios { get; }
    IUsuario Usuarios { get; }
    IRol Roles { get; }
    Task<int> SaveAsync();

}