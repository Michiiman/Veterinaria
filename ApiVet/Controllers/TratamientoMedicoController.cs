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
public class TratamientoMedicoController : ApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public TratamientoMedicoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TratamientoMedicoDto>>> Get()
    {
        var entidad = await unitOfWork.TratamientosMedicos.GetAllAsync();
        return mapper.Map<List<TratamientoMedicoDto>>(entidad);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TratamientoMedicoDto>>> GetPagination([FromQuery] Params EntidadParams)
    {
        var entidad = await unitOfWork.TratamientosMedicos.GetAllAsync(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<TratamientoMedicoDto>>(entidad.registros);
        return new Pager<TratamientoMedicoDto>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TratamientoMedicoDto>> Get(int id)
    {
        var entidad = await unitOfWork.TratamientosMedicos.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TratamientoMedicoDto>(entidad);
    }


    [HttpPost]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TratamientoMedico>> Post(TratamientoMedicoDto entidadDto)
    {
        var entidad = this.mapper.Map<TratamientoMedico>(entidadDto);
        this.unitOfWork.TratamientosMedicos.Add(entidad);
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
    public async Task<ActionResult<TratamientoMedicoDto>> Put(int id, [FromBody] TratamientoMedicoDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<TratamientoMedico>(entidadDto);
        unitOfWork.TratamientosMedicos.Update(entidad);
        await unitOfWork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitOfWork.TratamientosMedicos.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitOfWork.TratamientosMedicos.Remove(entidad);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
