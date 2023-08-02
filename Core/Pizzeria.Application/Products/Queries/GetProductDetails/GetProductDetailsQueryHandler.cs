using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Application.Common.Exceptions;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ErrorOr<ProductDetailsVm>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetProductDetailsQueryHandler(IPizzeriaDbContext dbContext, IMapper mapper, IUnitOfWork unitOfWork)
         =>(_mapper, _unitOfWork) = (mapper, unitOfWork);
           
        public async Task<ErrorOr<ProductDetailsVm>> Handle(GetProductDetailsQuery request, CancellationToken token)
        {
            if(!Guid.TryParse(request.Id.ToString(), out Guid result))
            {
                return Errors.Product.InvalidId;
            }

            var entity = await _unitOfWork.Products.GetProductById(request.Id);

            if (entity is null)
            {
                return Errors.Product.NotFound;
            }

            return _mapper.Map<ProductDetailsVm>(entity);
        }
    }
}
