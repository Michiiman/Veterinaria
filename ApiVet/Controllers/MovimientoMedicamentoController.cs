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

public class MovimientoMedicamentoController : ApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public MovimientoMedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MovimientoMedicamentoDto>>> Get()
    {
        var entidad = await unitOfWork.MovimientosMedicamentos.GetAllAsync();
        return mapper.Map<List<MovimientoMedicamentoDto>>(entidad);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MovimientoMedicamentoDto>>> GetPagination([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.MovimientosMedicamentos.GetAllAsync(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<MovimientoMedicamentoDto>>(entidad.registros);
        return new Pager<MovimientoMedicamentoDto>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MovimientoMedicamentoDto>> Get(int id)
    {
        var entidad = await unitOfWork.MovimientosMedicamentos.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<MovimientoMedicamentoDto>(entidad);
    }


    [HttpPost]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoMedicamento>> Post(MovimientoMedicamentoDto entidadDto)
    {
        var entidad = this.mapper.Map<MovimientoMedicamento>(entidadDto);
        this.unitOfWork.MovimientosMedicamentos.Add(entidad);
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
    public async Task<ActionResult<MovimientoMedicamentoDto>> Put(int id, [FromBody] MovimientoMedicamentoDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<MovimientoMedicamento>(entidadDto);
        unitOfWork.MovimientosMedicamentos.Update(entidad);
        await unitOfWork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitOfWork.MovimientosMedicamentos.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitOfWork.MovimientosMedicamentos.Remove(entidad);
        await unitOfWork.SaveAsync();
        return NoContent();
    }

    //EndPoints

    [HttpGet("TotalMovimientos")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<object>>> TotalMovimientos()
    {
        var entidad = await unitOfWork.MovimientosMedicamentos.TotalMovimientos();
        if (entidad == null)
        {
            return NotFound();
        }
        return Ok(this.mapper.Map<IEnumerable<object>>(entidad));
    }

    [HttpGet("TotalMovimientos")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<Object>>> TotalMovimientos([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.MovimientosMedicamentos.TotalMovimientos(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<Object>>(entidad.registros);
        return new Pager<Object>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

}

