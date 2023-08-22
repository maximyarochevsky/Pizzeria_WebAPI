using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Cart.Command.AddCartItem;
using Pizzeria.Application.Cart.Command.ClearCart;
using Pizzeria.Application.Cart.Command.DecrementCartItem;
using Pizzeria.Application.Cart.Command.IncrementCartItem;
using Pizzeria.Application.Cart.Command.RemoveCartItem;
using Pizzeria.Application.Cart.Queries.GetCart;
using Pizzeria.Contracts.Cart.Get;
using Microsoft.AspNetCore.Authorization;

namespace Pizzeria_WebAPI.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class CartController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CartController(IMediator mediator, IMapper mapper)
        => (_mediator, _mapper) = (mediator, mapper);


        [HttpPost("{id}")]
        public async Task<IActionResult> AddCartItem(Guid id, int quantity)
        {
            var command = new AddCartItemCommand(id, quantity);

            var result = await _mediator.Send(command);

            return result.MatchFirst(
                cartItem => Ok(result.Value),
                error => Problem(title: error.Description));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> IncrementCartItem(Guid id)
        {
            var command = new IncrementCartItemCommand(id);

            var result = await _mediator.Send(command);

            return result.MatchFirst(
                cartItem => Ok(result.Value),
                error => Problem(title: error.Description));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DecrementCartItem(Guid id)
        {
            var command = new DecrementCartItemCommand(id);

            var result = await _mediator.Send(command);

            return result.MatchFirst(
                cartItem => Ok(result.Value),
                error => Problem(title: error.Description));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCartItem(Guid id)
        {
            var command = new RemoveCartItemCommand(id);

            var result = await _mediator.Send(command);

            return result.MatchFirst(
                cartItem => Ok(result.Value),
                error => Problem(title: error.Description));
        }


        [HttpGet("getCart")]
        public async Task<IActionResult> GetCart()
        {
            var query = new GetCartQuery();

            var cart = await _mediator.Send(query);

            return cart.MatchFirst(
                cart => Ok(_mapper.Map<GetCartResponse>(cart)),
                error => Problem(title: error.Description));
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            var command = new ClearCartCommand();

            var result = await _mediator.Send(command);

            return result.MatchFirst(
                cartItem => Ok(result.Value),
                error => Problem(title: error.Description));
        }

    }
}
