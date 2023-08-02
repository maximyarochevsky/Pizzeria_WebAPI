using AutoMapper;
using ErrorOr;
using MediatR;
using Pizzeria.Application.Common.Exceptions;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Products.Queries.GetProductDetails;
using Pizzeria.Application.Products.Queries.ViewModels;

namespace Pizzeria.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery,ErrorOr<ListProductsVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
     => (_unitOfWork, _mapper) = (unitOfWork, mapper);
    public async Task<ErrorOr<ListProductsVm>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Products.GetAllProducts();

        if (products == null)

            return new ErrorOr<ListProductsVm>();

        var allProducts = products.Select(x => new ProductDetailsVm()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Price = x.Price,
            Section = x.Section.Name,
        }).ToList();

        return new ListProductsVm() { ListProducts = allProducts };
    }
}





