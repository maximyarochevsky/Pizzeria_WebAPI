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
                vmResponse => Ok(vmResponse),
                errors => Problem("Ошибка"));
        }
    }
}
