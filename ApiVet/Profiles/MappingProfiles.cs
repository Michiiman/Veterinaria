using ApiVet.Dtos;
using AutoMapper;
using Domain.Entities;

namespace ApiVet.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Cita, CitaDto>().ReverseMap();
        

    }
}
