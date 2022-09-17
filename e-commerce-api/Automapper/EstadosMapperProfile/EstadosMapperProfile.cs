using AutoMapper;
using e_commerce_api.DTO.Estados;
using e_commerce_api.Models;

namespace e_commerce_api.Automapper.EstadosMapperProfile
{
    public class EstadosMapperProfile : Profile
    {
        public EstadosMapperProfile()
        {
            CreateMap<Estado, EstadoDTO>()
                .ForMember(dest => dest.IdDTO, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NombreDTO, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.DescripcionDTO, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.FechaCreacionDTO, opt => opt.MapFrom(src => src.FechaCreacion));
        }
    }
}

