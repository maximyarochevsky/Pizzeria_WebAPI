using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Cart.Command;
using Pizzeria.Application.Cart.Command.AddCartItem;
using Pizzeria.Application.Cart.Command.ClearCart;
using Pizzeria.Application.Cart.Command.DecrementCartItem;
using Pizzeria.Application.Cart.Command.IncrementCartItem;
using Pizzeria.Application.Cart.Command.RemoveCartItem;
using Pizzeria.Application.Cart.Queries.GetCart;
using ErrorOr;
using Pizzeria.Contracts.Cart.Get;

using Pizzeria.Domain.Entities;
using System.Security.Cryptography;

namespace Pizzeria_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CartController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CartController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddCartItem(Guid id, int quantity)
        {
            var command = new AddCartItemCommand
            {
                ProductId = id,
                Quantity = quantity,
            };

            var result = await _mediator.Send(command);

            return result.Match(
                cartItem => Ok(result.Value),
                errors => Problem("Ошибка"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> IncrementCartItem(Guid id)
        {
            var command = new IncrementCartItemCommand()
            {
                ProductId = id,
            };

            var result = await _mediator.Send(command);

            return result.Match(
                cartItem => Ok(result.Value),
                errors => Problem("Ошибка"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DecrementCartItem(Guid id)
        {
            var command = new DecrementCartItemCommand()
            {
                ProductId = id,
            };

            var result = await _mediator.Send(command);

            return result.Match(
                cartItem => Ok(result.Value),
                errors => Problem("Ошибка"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCartItem(Guid id)
        {
            var command = new RemoveCartItemCommand()
            {
                ProductId = id,
            };

            var result = await _mediator.Send(command);

            return result.Match(
                cartItem => Ok(result.Value),
                errors => Problem("Ошибка"));
        }


        [HttpGet("getCart")]
        public async Task<IActionResult> GetCart()
        {
            var query = new GetCartQuery();

            var cart = await _mediator.Send(query);

            return cart.Match(
                cart => Ok(_mapper.Map<GetCartResponse>(cart)),
                errors => Problem("Ошибка"));
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            var command = new ClearCartCommand();

            var result = await _mediator.Send(command);

            return result.Match(
                cartItem => Ok(result.Value),
                errors => Problem("Ошибка"));
        }

    }
}
