using AutoMapper;
using Entities;
using Services.Contracts;

namespace Services.Implementations
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Created,
                opt => opt.MapFrom(src =>
                    src.Created.ToString("yyyy-MM-dd HH:mm.ss")));
            CreateMap<OrderDTO, Order>();
            CreateMap<LineItem, LineItemDTO>();
            CreateMap<LineItemDTO, LineItem>();

            CreateMap<OrderDTO, OrderDTOCreate>();
            CreateMap<OrderDTOCreate, OrderDTO>();

            CreateMap<Order, OrderDTOCreate>();
            CreateMap<OrderDTOCreate, Order>();


        }
    }
}
