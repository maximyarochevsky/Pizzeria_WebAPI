using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Orders.Commands.CreateOrder;
using Pizzeria.Application.Orders.Queries.GetAllOrders;
using AutoMapper;
using Pizzeria.Contracts.Order.Get;
using Pizzeria.Application.Orders.Queries.GetOrderById;
using Microsoft.AspNetCore.Authorization;

namespace Pizzeria_WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        => (_mediator, _mapper) = (mediator, mapper);


        [HttpPost("createOrder")]
        public async Task<IActionResult> CreateOrder(string address, string phone, string? description)
        {
            var command = new CreateOrderCommand(
                address,
                phone,
                description);
            
            var vm = await _mediator.Send(command);

            return vm.MatchFirst(
                order => Ok(vm.Value),
                error => Problem(title: error.Description));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        { 
            var query = new GetAllOrdersQuery();

            var vm = await _mediator.Send(query);

            return vm.MatchFirst(
                vm => Ok(_mapper.Map<GetAllOrdersResponse>(vm)),
                error => Problem(title: error.Description));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var query = new GetOrderByIdQuery(id);

            var vm = await _mediator.Send(query);

            return vm.MatchFirst(
                vm => Ok(_mapper.Map<GetOrderResponse>(vm)),
                error => Problem(title: error.Description));
        }
    }
}
