using Entities;
using Services.Contracts;

namespace Services.Abstraction
{
    public interface IOrderService
    {
        Task<OrderDTO> GetById(Guid id);

        Task<OrderDTO> Create(OrderDTO orderDto);

        Task<OrderDTO> Update(Guid id, OrderDTOUpdate orderDto);

        void Delete(Guid id);
    }
}