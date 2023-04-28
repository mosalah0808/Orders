using AutoMapper;
using Entities;
using Services.Contracts;

namespace Services.Implementations
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<LineItem, LineItemDTO>();
            CreateMap<LineItemDTO, LineItem>();

            CreateMap<Order, OrderDTOCreate>();
            CreateMap<OrderDTOCreate, Order>();

        }
    }
}
