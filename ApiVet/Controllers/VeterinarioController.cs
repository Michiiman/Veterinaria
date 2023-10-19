using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ApiVet.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace ApiVet.Controllers;
public class VeterinarioController : ApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public VeterinarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> Get()
    {
        var entidad = await unitOfWork.Veterinarios.GetAllAsync();
        return mapper.Map<List<VeterinarioDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VeterinarioDto>> Get(int id)
    {
        var entidad = await unitOfWork.Veterinarios.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<VeterinarioDto>(entidad);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Veterinario>> Post(VeterinarioDto entidadDto)
    {
        var entidad = this.mapper.Map<Veterinario>(entidadDto);
        this.unitOfWork.Veterinarios.Add(entidad);
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
    public async Task<ActionResult<VeterinarioDto>> Put(int id, [FromBody] VeterinarioDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Veterinario>(entidadDto);
        unitOfWork.Veterinarios.Update(entidad);
        await unitOfWork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitOfWork.Veterinarios.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitOfWork.Veterinarios.Remove(entidad);
        await unitOfWork.SaveAsync();
        return NoContent();
    }

    //EndPoints

    [HttpGet("VetCirujanos")]
    public async Task<ActionResult<IEnumerable<object>>> VetCirujanos()
    {
        var entidad = await unitOfWork.Veterinarios.VetCirujanos();
        if (entidad == null)
        {
            return NotFound();
        }
        return Ok(this.mapper.Map<IEnumerable<object>>(entidad));
    }
}
