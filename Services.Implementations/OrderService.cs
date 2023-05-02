using AutoMapper;
using Entities;
using Services.Abstraction;
using Services.Contracts;
using Services.Repositories.Abstractions;


namespace Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        private static readonly string[] statuses = new[]
       {
             "New", "Awaiting Payment", "Paid", "In Transit", "Delivered", "Completed"
        };
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Create(OrderDTO orderDto)
        {
            var entity = _mapper.Map<OrderDTO, Order>(orderDto);
            entity.Created = DateTime.UtcNow;
            entity.Status = statuses[0];
            var res = await _orderRepository.AddAsync(entity);
            _orderRepository.SaveChanges();
            return _mapper.Map<Order,OrderDTO>(res); 
        }

        public void Delete(Guid id)
        {
             _orderRepository.DeleteById(id);
             _orderRepository.SaveChanges();
        }

        public async Task<OrderDTO> GetById(Guid id)
        {
            var order = await _orderRepository.GetById(id);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO>  Update(Guid id, OrderDTOUpdate orderDto)
        {
            var order = await _orderRepository.GetById(id);
            order.Status = orderDto.Status;
           
            foreach (var lineItemDto in orderDto.Lines)
            {
                var lineItem = order.Lines.FirstOrDefault(l => l.Id == lineItemDto.Id);

                if (lineItem == null)
                {
                    return null;
                }

                lineItem.Id = lineItemDto.Id;
                lineItem.Qty = lineItemDto.Qty;
            }

            _orderRepository.Update(order);
             _orderRepository.SaveChanges();
            return _mapper.Map<Order, OrderDTO>(order);
        }
    }
}