using AutoMapper;
using Eduvista.Entities.Entities;
using Eduvista.WebAPI.DTOs.ClassControllerDTOs;

namespace Eduvista.WebAPI.AutoMappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Class, AddClassDTO>().ReverseMap();
        CreateMap<Class, ClassDTO>().ReverseMap();
    }
}
