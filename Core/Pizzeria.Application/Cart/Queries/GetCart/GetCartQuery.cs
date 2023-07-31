using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Pizzeria.Application.Cart.Queries.GetCart;

public class GetCartQuery : IRequest<Domain.Entities.Cart>
{
}
