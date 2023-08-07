using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Orders.Commands.CreateOrder;
using Pizzeria.Domain.Entities;
using ErrorOr;
using System.Globalization;
using Microsoft.AspNetCore.Http.HttpResults;
using Pizzeria.Application.Orders.Queries.GetAllOrders;
using AutoMapper;
using Pizzeria.Contracts.Order.Get;
using Pizzeria.Application.Orders.Queries.ViewModels;
using Pizzeria.Contracts.Product.Get;
using Pizzeria.Application.Orders.Queries.GetOrderById;

namespace Pizzeria_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("createOrder")]
        public async Task<IActionResult> CreateOrder(string address, string phone, string description)
        {
            var command = new CreateOrderCommand()
            {
                Address = address,
                Phone = phone,
                Description = description
            };
            var vm = await _mediator.Send(command);

            return vm.Match(
                order => Ok(vm.Value),
                errors => Problem("Ошибка"));
        }

        [HttpGet("all")]

        public async Task<IActionResult> GetAllOrders()
        { 
            var query = new GetAllOrdersQuery();

            var vm = await _mediator.Send(query);

            return vm.Match(
                vm => Ok(_mapper.Map<GetAllOrdersResponse>(vm)),
                errors => Problem("Ошибка"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var query = new GetOrderByIdQuery()
            {
                Id = id,
            };

            var vm = await _mediator.Send(query);

            return vm.Match(
                vm => Ok(_mapper.Map<GetOrderResponse>(vm)),
                errors => Problem("Ошибка"));
        }
    }
}
