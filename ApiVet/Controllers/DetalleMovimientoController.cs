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

public class DetalleMovimientoController : ApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public DetalleMovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleMovimientoDto>>> Get()
    {
        var entidad = await unitOfWork.DetallesMovimientos.GetAllAsync();
        return mapper.Map<List<DetalleMovimientoDto>>(entidad);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetalleMovimientoDto>>> GetPagination([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.DetallesMovimientos.GetAllAsync(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<DetalleMovimientoDto>>(entidad.registros);
        return new Pager<DetalleMovimientoDto>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleMovimientoDto>> Get(int id)
    {
        var entidad = await unitOfWork.DetallesMovimientos.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<DetalleMovimientoDto>(entidad);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleMovimiento>> Post(DetalleMovimientoDto entidadDto)
    {
        var entidad = this.mapper.Map<DetalleMovimiento>(entidadDto);
        this.unitOfWork.DetallesMovimientos.Add(entidad);
        await unitOfWork.SaveAsync();
        if (entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new { id = entidadDto.Id }, entidadDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleMovimientoDto>> Put(int id, [FromBody] DetalleMovimientoDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<DetalleMovimiento>(entidadDto);
        unitOfWork.DetallesMovimientos.Update(entidad);
        await unitOfWork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitOfWork.DetallesMovimientos.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitOfWork.DetallesMovimientos.Remove(entidad);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
