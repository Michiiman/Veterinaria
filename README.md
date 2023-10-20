# veterinaria

Este proyecto proporciona una API que permite gestionar todo el apartado de la administración de una veterinaria y gestion de los usuarios.

## Características 🌟

- Registro de usuarios.
- Autenticación con usuario y contraseña.
- Generación y utilización del token.
- CRUD completo para cada entidad.
- Vista de las consultas requeridas.
- Para cada controlador GET una version con paginacion y otra sin paginacion.

## Uso 🕹

Una vez que el proyecto esté en marcha, puedes acceder a los diferentes endpoints disponibles:

primero que todo, en los csv esta el administrador con el usuario:admin y la contraseña : 123
del cual nesecitaremos el token para el registro de usuarios ya que solo el administrador podra hacer todo con respecto al crud de los usuarios:

## POST de las entidades

**Citas**  

       **Endpoint**: `http://localhost:5278/api/veterinaria/cita`
       
       **Método**: `POST`
       
       **Payload**:
       
       {
          "mascotaIdFk": 1,
          "fecha": "2022-03-25",
          "hora": "09:25:00",
          "motivo": "Vacunacion",
          "veterinarioIdFk": 1
        }
      
**Detalle Movimiento**  

       **Endpoint**: `http://localhost:5278/vet/DetalleMovimiento`
       
       **Método**: `POST`
       
       **Payload**:
       
       {
          "medicamentoIdFk": 2,
          "cantidad": 100,
          "movimientoMedicamentoIdFk": 2,
          "precio": 50000
        }
      
**Especie**  

       **Endpoint**: `http://localhost:5278/vet/especie`
       
       **Método**: `POST`
       
       **Payload**:
       
      {
        "Nombre":"Aracnido"
      }  
      
**Laboratorio**  

       **Endpoint**: `http://localhost:5278/vet/laboratorio`
       
       **Método**: `POST`
       
       **Payload**:
       
       {
          "nombre": "Mk",
          "direccion": "Direccion MKl",
          "telefono": "6584578"
        }

**Mascota**  

       **Endpoint**: `http://localhost:5278/vet/mascota`
       
       **Método**: `POST`
       
       **Payload**:
       
        {
          "propietarioIdFk": 2,
          "razaIdFk": 3,
          "nombre": "Pecas",
          "fechaNacimiento": "2019-10-20"
        }
      

      
**Medicamento**  

       **Endpoint**: `http://localhost:5278/vet/medicamento`
       
       **Método**: `POST`
       
       **Payload**:
       
      {
        "Nombre":"Metanipzolona",
        "cantidadDisponible":15,
        "Precio":20000,
        "laboratorioIdFk":2
      }
      

**MovimientoMedicamento**  

       **Endpoint**: `http://localhost:5278/vet/movimientoMedicamento`
       
       **Método**: `POST`
       
       **Payload**:
       
     {
        "Cantidad":1,
        "Fecha":"2023-05-12",
        "tipoMovimientoIdFk":2
      }


**Propietario**  

       **Endpoint**: `http://localhost:5278/vet/propietario`
       
       **Método**: `POST`
       
       **Payload**:
       
     {
        "Nombre":"Camilo",
        "Email":"correo@gmail.com",
        "Telefono":"789456"
      }


**Proveedor**  

       **Endpoint**: `http://localhost:5278/vet/proveedor`
       
       **Método**: `POST`
       
       **Payload**:
       
     {
        "Nombre":"Winston",
        "Direccion":"Cañaveral Campestre",
        "Telefono":"456123"
      }
**Raza**  

       **Endpoint**: `http://localhost:5278/vet/raza`
       
       **Método**: `POST`
       
       **Payload**:
       
     {
        "especieIdFk":1,
        "Nombre":"Pastor Aleman"
      }  

**TratamientoMedico**  

       **Endpoint**: `http://localhost:5278/vet/tratamientoMedico`
       
       **Método**: `POST`
       
       **Payload**:
       
    {
        "citaIdFk":1,
        "medicamentoIdFk": 3,
        "Dosis": 5,
        "FechaAdministracion": "2023-04-05",
        "Observacion": "Limitación"
      } 

**TipoMovimiento**  

       **Endpoint**: `http://localhost:5278/vet/tipoMovimiento`
       
       **Método**: `POST`
       
       **Payload**:
       
    {
        "Descripcion": "Entrada"
      }    


**Veterinario**  

       **Endpoint**: `http://localhost:5278/vet/veterinario`
       
       **Método**: `POST`
       
       **Payload**:
       
    {
        "Nombre":"Owen",
        "Email":"correo@gmail.com",
        "Telefono":"123456",
        "Especialidad": "Cirujano Vascular"
      }          


## 1. Generación del token:

       **Endpoint**: `http://localhost:5278/vet/token`
       
       **Método**: `POST`
       
       **Payload**:
       
       `{
           "Nombre": "<nombre_de_usuario>",
           "password": "<password>"
       }`
una vez que tenemos el token del administrador, ya podremos hacer el registro de usuario ingresandolo en el auth:
## 2. Registro de Usuarios

      **Endpoint**: `http://localhost:5278/vet/register`
      
      **Método**: `POST`
      
      **Payload**:
      
      json
      `{
          "Nombre": "<nombre_de_usuario>",
          "password": "<password>",
          "Email": "<Email>"
      }`

Una vez registrado el usuario tendrá que ingresar para recibir un token, este será ingresado al siguiente Endpoint que es el de Refresh Token para poder ingresar a los demas controladores.

## 3. Refresh Token:

      **Endpoint**: `http://localhost:5278/vet/refresh-token`
      
      **Método**: `POST`
      
      **Payload**:
      
      `{
          "Nombre": "<nombre_de_usuario>",
          "password": "<password>"
      }`

Se dejan los mismos datos en el Body y luego se ingresa al "Auth", "Bearer", allí se ingresa el token obtenido en el anterior Endpoint.

      **Otros Endpoints**
      recordar que para todos los endpoints tenemos que tener el token de rol de administrador
      
      Obtener Todos los Usuarios: GET `http://localhost:5278/vet/usuario`
      
      Obtener Usuario por ID: GET `http://localhost:5278/vet/usuario/{id}`
      
      Actualizar Usuario: PUT `http://localhost:5278/vet/usuario/{id}`
      
      Eliminar Usuario: DELETE `http://localhost:5278/vet/usuario/{id}`
      

## Desarrollo de los Endpoints requeridos⌨️

Cada Endpoint  se maneja en su versión 1.0 y 1.1. Siendo la primera sin paginación y la segunda con paginación.

Para consultar la versión 1.0 de todos se ingresa únicamente el Endpoint; para consultar la versión 1.1 se deben seguir los siguientes pasos: 

En el Thunder Client se va al apartado de "Headers" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/8044ee3d-76d9-4437-9f08-da8e5d7cff9a)

Para realizar la paginación se va al apartado de "Query" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/22683e46-037e-4f30-96b8-161df8622b40)


## 1. Visualizar los veterinarios cuya especialidad sea Cirujano vascular:

      **Endpoint**: `http://localhost:5278/vet/veterinario/VetCirujanos`
      
      **Método**: `GET`


## 2. Listar los medicamentos que pertenezcan a el laboratorio Genfar:
      
      **Endpoint**: `http://localhost:5278/vet/medicamento/MedGenfar`
      
      **Método**: `GET`


## 3. Mostrar las mascotas que se encuentren registradas cuya especie sea felina:

      **Endpoint**: `http://localhost:5278/vet/mascota/MascotasFelinas`
      
      **Método**: `GET`


## 4. Listar los propietarios y sus mascotas:

      **Endpoint**: `http://localhost:5278/vet/propietario/PropietariosMascotas`
      
      **Método**: `GET`


## 5. Listar los medicamentos que tenga un precio de venta mayor a 50000:

      **Endpoint**: `http://localhost:5278/vet/medicamento/MedMayor50k`
      
      **Método**: `GET`


## 6. Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023:

      **Endpoint**: `http://localhost:5278/vet/mascota/MascotasVacunadas`
      
      **Método**: `GET`


## 7. Listar todas las mascotas agrupadas por especie:

      **Endpoint**: `http://localhost:5278/vet/mascota/MascotasPorEspecie`
      
      **Método**: `GET`


## 8. Listar todos los movimientos de medicamentos y el valor total de cada movimiento:

      **Endpoint**: `http://localhost:5278/vet/movimientoMedicamento/TotalMovimientos`
      
      **Método**: `GET`


## 9. Listar las mascotas que fueron atendidas por un determinado veterinario:

      **Endpoint**: `http://localhost:5278/vet/mascota/MascotasPorVeterinario`
      
      **Método**: `GET`

## 10. Listar los proveedores que me venden un determinado medicamento:

      **Endpoint**: `http://localhost:5278/vet/proveedor/ProveedoresMedicamentos`
      
      **Método**: `GET`

## 11. Listar las mascotas y sus propietarios cuya raza sea Golden Retriver:

      **Endpoint**: `http://localhost:5278/vet/propietario/MascotasGoldenRetriever`
      
      **Método**: `GET`

## 12. Listar la cantidad de mascotas que pertenecen a una raza:

      **Endpoint**: `http://localhost:5278/vet/mascota/MascotasPorRaza`
      
      **Método**: `GET`

## Desarrollo ⌨️
Este proyecto utiliza varias tecnologías y patrones, incluidos:

Entity Framework Core para la ORM.
Patrón Repository y Unit of Work para la gestión de datos.
AutoMapper para el mapeo entre entidades y DTOs.
El proyecto esta construido en 4 capas.

## Agradecimientos 🎁

A Owen 🦝
