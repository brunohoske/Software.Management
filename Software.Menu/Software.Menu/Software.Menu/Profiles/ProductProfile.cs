using AutoMapper;
using MercadoPago.Resource.User;
using Software.Menu.DTOs;
using Software.Menu.Models;

namespace Software.Menu.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.Value, map => map.MapFrom(src => src.Value))
                .ForMember(dst => dst.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dst => dst.Image, map => map.MapFrom(src => src.Image))
                .ForMember(dst => dst.Category, map => map.MapFrom(src => src.Category))
                .ForMember(dst => dst.Store, map => map.MapFrom(src => src.Store)
                );

            CreateMap<Combo, ProductDTO>()
               .ForMember(dst => dst.Id, map => map.MapFrom(src => src.Id))
               .ForMember(dst => dst.Value, map => map.MapFrom(src => src.Value))
               .ForMember(dst => dst.Name, map => map.MapFrom(src => src.Name))
               .ForMember(dst => dst.Image, map => map.MapFrom(src => src.Image))
               .ForMember(dst => dst.Category, map => map.MapFrom(src => src.Category))
               .ForMember(dst => dst.Store, map => map.MapFrom(src => src.Store)
               );
        }
    }
}
