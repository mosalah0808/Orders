using Entities;
using Services.Contracts;

namespace Services.Abstraction
{
    public interface IOrderService
    {
        Task<OrderDTO> GetById(Guid id);

        Task<Order> Create(OrderDTOCreate orderDto);

        Task<Order> Update(Guid id, OrderDTOUpdate orderDto);

        void Delete(Guid id);
    }
}