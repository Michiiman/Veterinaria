using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence;
public class ApiVetContextSeed
{
    public static async Task SeedAsync(ApiVetContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            //inicio de las insersiones en la db
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.Veterinarios.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/Veterinario.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Veterinario>();
                        context.Veterinarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Especies.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/Especie.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Especie>();
                        context.Especies.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Razas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/Raza.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Raza>();
                        List<Raza> entidad = new List<Raza>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Raza
                            {
                                Id = item.Id,
                                EspecieIdFk = item.EspecieIdFk,
                                Nombre = item.Nombre
                            });
                        }
                        context.Razas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Propietarios.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/Propietario.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Propietario>();
                        context.Propietarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Proveedores.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/Proveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Proveedor>();
                        context.Proveedores.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Usuarios.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/Usuario.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Usuario>();
                        context.Usuarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
                
            }
            if (!context.Laboratorios.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/Laboratorio.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Laboratorio>();
                        context.Laboratorios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TiposMovimientos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/TipoMovimiento.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<TipoMovimiento>();
                        context.TiposMovimientos.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            
            if (!context.Medicamentos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/Medicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Medicamento>();
                        List<Medicamento> entidad = new List<Medicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Medicamento
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                CantidadDisponible = item.CantidadDisponible,
                                Precio = item.Precio,
                                LaboratorioIdFk = item.LaboratorioIdFk
                            });
                        }
                        context.Medicamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Mascotas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/Mascota.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Mascota>();
                        List<Mascota> entidad = new List<Mascota>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Mascota
                            {
                                Id = item.Id,
                                PropietarioIdFk = item.PropietarioIdFk,
                                RazaIdFk = item.RazaIdFk,
                                Nombre = item.Nombre,
                                FechaNacimiento = item.FechaNacimiento
                            });
                        }
                        context.Mascotas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            
            if (!context.Citas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/Cita.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Cita>();
                        List<Cita> entidad = new List<Cita>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Cita
                            {
                                Id = item.Id,
                                MascotaIdFk = item.MascotaIdFk,
                                Fecha = item.Fecha,
                                Hora = item.Hora,
                                Motivo = item.Motivo,
                                VeterinarioIdFk = item.VeterinarioIdFk
                            });
                        }
                        context.Citas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.MedicamentosProveedores.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/MedicamentoProveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<MedicamentoProveedor>();
                        List<MedicamentoProveedor> entidad = new List<MedicamentoProveedor>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MedicamentoProveedor
                            {
                                MedicamentoIdFk = item.MedicamentoIdFk,
                                ProveedorIdFk = item.ProveedorIdFk 
                            });
                        }
                        context.MedicamentosProveedores.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.MovimientosMedicamentos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/MovimientoMedicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<MovimientoMedicamento>();
                        List<MovimientoMedicamento> entidad = new List<MovimientoMedicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MovimientoMedicamento
                            {
                                Id = item.Id,
                                Fecha = item.Fecha,
                                TipoMovimientoIdFk = item.TipoMovimientoIdFk,
                            });
                        }
                        context.MovimientosMedicamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }            
            if (!context.DetallesMovimientos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/DetalleMovimiento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<DetalleMovimiento>();
                        List<DetalleMovimiento> entidad = new List<DetalleMovimiento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new DetalleMovimiento
                            {
                                Id = item.Id,
                                MedicamentoIdFk = item.MedicamentoIdFk,
                                Cantidad = item.Cantidad,
                                MovimientoMedicamentoIdFk = item.MovimientoMedicamentoIdFk,
                                Precio = item.Precio
                            });
                        }
                        context.DetallesMovimientos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TratamientosMedicos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/TratamientoMedico.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<TratamientoMedico>();
                        List<TratamientoMedico> entidad = new List<TratamientoMedico>();
                        foreach (var item in list)
                        {
                            entidad.Add(new TratamientoMedico
                            {
                                Id = item.Id,
                                CitaIdFk = item.CitaIdFk,
                                MedicamentoIdFk = item.MedicamentoIdFk,
                                Dosis = item.Dosis,
                                FechaAdministracion = item.FechaAdministracion,
                                Observacion = item.Observacion,
                            });
                        }
                        context.TratamientosMedicos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.RolesUsuarios.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csv/RoleUser.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<RolUsuario>();
                        List<RolUsuario> entidad = new List<RolUsuario>();
                        foreach (var item in list)
                        {
                            entidad.Add(new RolUsuario
                            {
                                UsuarioIdFk = item.UsuarioIdFk,
                                RolIdFk = item.RolIdFk
                            });
                        }
                        context.RolesUsuarios.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
        //fin de las insersiones en la db
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiVetContext>();
            logger.LogError(ex.Message);
        }
    }
    public static async Task SeedRolesAsync(ApiVetContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Rol>()
                        {
                            new Rol{Id=1, Nombre="Administrador"},
                            new Rol{Id=2, Nombre="Empleado"},
                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiVetContext>();
            logger.LogError(ex.Message);
        }
    }
}
