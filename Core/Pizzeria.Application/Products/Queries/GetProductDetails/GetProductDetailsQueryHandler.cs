using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Products.Queries.ViewModels;

namespace Pizzeria.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetProductDetailsQueryHandler(IPizzeriaDbContext dbContext, IMapper mapper, IUnitOfWork unitOfWork)
         =>(_mapper, _unitOfWork) = (mapper, unitOfWork);
           
        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request, CancellationToken token)
        {
            var entity = await _unitOfWork.Products.GetProductById(request.Id);

            if (entity is null)
            {
                throw new ArgumentException();
            }

            return _mapper.Map<ProductDetailsVm>(entity);
        }
    }
}
