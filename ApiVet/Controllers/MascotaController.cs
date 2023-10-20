using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiVet.Dtos;
using ApiVet.Helpers.Errors;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ApiVet.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
//[Authorize]

public class MascotaController : ApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public MascotaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> Get()
    {
        var entidad = await unitOfWork.Mascotas.GetAllAsync();
        return mapper.Map<List<MascotaDto>>(entidad);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MascotaDto>>> GetPagination([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.Mascotas.GetAllAsync(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<MascotaDto>>(entidad.registros);
        return new Pager<MascotaDto>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MascotaDto>> Get(int id)
    {
        var entidad = await unitOfWork.Mascotas.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<MascotaDto>(entidad);
    }


    [HttpPost]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Mascota>> Post(MascotaDto entidadDto)
    {
        var entidad = this.mapper.Map<Mascota>(entidadDto);
        this.unitOfWork.Mascotas.Add(entidad);
        await unitOfWork.SaveAsync();
        if (entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new { id = entidadDto.Id }, entidadDto);
    }

    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody] MascotaDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Mascota>(entidadDto);
        unitOfWork.Mascotas.Update(entidad);
        await unitOfWork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitOfWork.Mascotas.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitOfWork.Mascotas.Remove(entidad);
        await unitOfWork.SaveAsync();
        return NoContent();
    }


    //EndPoints

    [HttpGet("MascotasFelinas")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> MascotasFelinas()
    {
        var entidad = await unitOfWork.Mascotas.MascotasFelinas();
        if (entidad == null)
        {
            return NotFound();
        }
        return Ok(this.mapper.Map<IEnumerable<object>>(entidad));
    }

    [HttpGet("MascotasFelinas")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Object>>> MascotasFelinas([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.Mascotas.MascotasFelinas(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<Object>>(entidad.registros);
        return new Pager<Object>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

    [HttpGet("MascotasPorEspecie")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MascotasPorEspecie()
    {
        var entidad = await unitOfWork.Mascotas.MascotasPorEspecie();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpGet("MascotasPorEspecie")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Object>>> MascotasPorEspecie([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.Mascotas.MascotasPorEspecie(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<Object>>(entidad.registros);
        return new Pager<Object>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

    [HttpGet("MascotasVacunadas")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MascotasVacunadas()
    {
        var entidad = await unitOfWork.Mascotas.MascotasVacunadas();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpGet("MascotasVacunadas")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Object>>> MascotasVacunadas([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.Mascotas.MascotasVacunadas(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<Object>>(entidad.registros);
        return new Pager<Object>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

    [HttpGet("MascotasPorVeterinario")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MascotasPorVeterinario()
    {
        var entidad = await unitOfWork.Mascotas.MascotasPorVeterinario();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpGet("MascotasPorVeterinario")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Object>>> MascotasPorVeterinario([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.Mascotas.MascotasPorVeterinario(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<Object>>(entidad.registros);
        return new Pager<Object>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

    [HttpGet("MascotasGoldenRetriever")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MascotasGoldenRetriever()
    {
        var entidad = await unitOfWork.Mascotas.MascotasGoldenRetriever();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpGet("MascotasGoldenRetriever")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Object>>> MascotasGoldenRetriever([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.Mascotas.MascotasGoldenRetriever(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<Object>>(entidad.registros);
        return new Pager<Object>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

}
