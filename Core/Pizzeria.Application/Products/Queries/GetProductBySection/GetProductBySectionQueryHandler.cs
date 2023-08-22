using AutoMapper;
using ErrorOr;
using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Domain.Entities;
using Pizzeria.Application.Common.Exceptions;

namespace Pizzeria.Application.Products.Queries.GetProductBySection;

public class GetProductBySectionQueryHandler : IRequestHandler<GetProductBySectionQuery, ErrorOr<ListProductsVm>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetProductBySectionQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
     => (_mapper, _unitOfWork) = (mapper, unitOfWork);

    public async Task<ErrorOr<ListProductsVm>> Handle(GetProductBySectionQuery request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.SectionId.ToString(), out Guid result))
            return Errors.Section.InvalidId;
       

        var products = await _unitOfWork.Products.GetProductsBySection(request.SectionId);

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

        return new ListProductsVm(allProducts);
    }
}

