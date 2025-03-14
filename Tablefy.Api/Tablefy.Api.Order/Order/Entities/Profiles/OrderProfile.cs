using AutoMapper;
using Tablefy.Order.Api.Order.Entities.Relations;
using Tablefy.Order.Api.Order.Models;

namespace Tablefy.Order.Api.Order.Entities.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderItemModel, OrderItemEntity>()
                .ForMember(dest => dest.AddedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<OrderCreateModel, OrderEntity>()
               .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
               .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<OrderItemEntity, OrderItemDisplayModel>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.TempImage));
            CreateMap<OrderEntity, OrderDisplayModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));
        }
    }
}
