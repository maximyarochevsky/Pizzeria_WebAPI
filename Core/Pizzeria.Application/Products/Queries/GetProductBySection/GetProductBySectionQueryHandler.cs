using AutoMapper;
using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Products.Queries.GetProductBySection;

public class GetProductBySectionQueryHandler : IRequestHandler<GetProductBySectionQuery, ListProductsVm>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetProductBySectionQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
     => (_mapper, _unitOfWork) = (mapper, unitOfWork);

    public async Task<ListProductsVm> Handle(GetProductBySectionQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Products.GetProductsBySection(request.SectionId);

        if (products == null)
            throw new ArgumentException();

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

