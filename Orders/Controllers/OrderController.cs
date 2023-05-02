using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Abstraction;
using Services.Contracts;
using System.Collections.Generic;
using System.ComponentModel;

namespace Orders.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        private readonly IMapper _mapper;

        public OrderController(IOrderService order, IMapper mapper)
        {
            _order = order;
            _mapper = mapper;
        }

       [HttpPost("")]
        public async Task<IActionResult> Create(OrderDTOCreate orderCreateDTO)
        {
            var order = await _order.GetById(orderCreateDTO.Id);

            if (order != null)
            {
                return BadRequest("Id уже существует!");
            }
            OrderDTO orderDto = _mapper.Map<OrderDTO>(orderCreateDTO);

            return Ok((await _order.Create(orderDto)));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _order.GetById(id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrderDTO>(order));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, OrderDTOUpdate orderDTOUpdate)
        {
            var order = await _order.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            if (order.Status == "Paid" || order.Status == "In Transit" || order.Status == "Delivered" || order.Status == "Completed")
            {
                return BadRequest("заказы в статусах “оплачен”, “передан в доставку”, “доставлен”, “завершен” нельзя редактировать");
            }

            return Ok(await _order.Update(order.Id, orderDTOUpdate));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var order = await _order.GetById(id);

            if (order == null)
            {
                return NotFound();
            }
            if ( order.Status == "In Transit" || order.Status == "Delivered" || order.Status == "Completed")
            {
                return BadRequest("заказы в статусах “передан в доставку”, “доставлен”, “завершен” нельзя удалить");
            }
            _order.Delete(id);
            return StatusCode(200);
        }
    }
}