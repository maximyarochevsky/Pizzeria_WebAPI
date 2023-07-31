using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Pizzeria.Application.Cart.Queries.GetCart;

public class GetCartQuery : IRequest<List<CartItem>>
{
}
