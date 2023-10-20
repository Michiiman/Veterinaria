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
[Authorize]

public class PropietarioController : ApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public PropietarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PropietarioDto>>> Get()
    {
        var entidad = await unitOfWork.Propietarios.GetAllAsync();
        return mapper.Map<List<PropietarioDto>>(entidad);
    }
    
    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PropietarioDto>>> GetPagination([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.Propietarios.GetAllAsync(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<PropietarioDto>>(entidad.registros);
        return new Pager<PropietarioDto>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioDto>> Get(int id)
    {
        var entidad = await unitOfWork.Propietarios.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<PropietarioDto>(entidad);
    }


    [HttpPost]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Propietario>> Post(PropietarioDto entidadDto)
    {
        var entidad = this.mapper.Map<Propietario>(entidadDto);
        this.unitOfWork.Propietarios.Add(entidad);
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
    public async Task<ActionResult<PropietarioDto>> Put(int id, [FromBody] PropietarioDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Propietario>(entidadDto);
        unitOfWork.Propietarios.Update(entidad);
        await unitOfWork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitOfWork.Propietarios.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitOfWork.Propietarios.Remove(entidad);
        await unitOfWork.SaveAsync();
        return NoContent();
    }

    //EndPoints
    [HttpGet("PropietariosMascotas")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> PropietariosMascotas()
    {
        var entidad = await unitOfWork.Propietarios.PropietariosMascotas();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpGet("PropietariosMascotas")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Object>>> PropietariosMascotas([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.Propietarios.PropietariosMascotas(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<Object>>(entidad.registros);
        return new Pager<Object>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }
}
