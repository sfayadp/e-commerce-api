using AutoMapper;
using e_commerce_api.DTO.Descuentos;
using e_commerce_api.Models;

namespace e_commerce_api.Automapper.DescuentosMapperProfile
{
    public class DescuentosMapperProfile : Profile
    {
        public DescuentosMapperProfile()
        {
            CreateMap<Descuento, DescuentoDTO>()
                .ForMember(dest => dest.IdDTO, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NombreDTO, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.CodigoDTO, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.ValorPorcentajeDTO, opt => opt.MapFrom(src => src.ValorPorcentaje));
        }
    }
}
