using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Cart.Command;
using Pizzeria.Application.Cart.Queries.GetCart;
using Pizzeria.Domain.Entities;

namespace Pizzeria_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CartController:ControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
                _mediator = mediator;
        }

        [HttpPost("cart/addCartItem/{id}")]
        public async Task<ActionResult<CartItem>> AddCartItem(Guid id, int quantity)
        {
            var command = new AddCartItemCommand
            {
                ProductId = id,
                Quantity = quantity,
            };

            var cartItem = await _mediator.Send(command);

            return Ok(cartItem);
        }

        [HttpGet("cart/getCart")]
        public async Task<ActionResult<List<CartItem>>> GetCart()
        {
            var query = new GetCartQuery();

            var list = await _mediator.Send(query);

            return Ok(list);
        }
    }
}
