using ErrorOr;
using MediatR;
using Pizzeria.Application.Cart.Queries.ViewModels;

namespace Pizzeria.Application.Cart.Queries.GetCart;

public record GetCartQuery() : IRequest<ErrorOr<CartVm>>;

