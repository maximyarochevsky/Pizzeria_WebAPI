using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Interfaces;

namespace Pizzeria.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IPizzeriaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IPizzeriaDbContext dbContext, IMapper mapper)
         =>(_dbContext, _mapper) = (dbContext,mapper);
           
        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request, CancellationToken token)
        {
            var entity = await _dbContext.Products
                .FirstOrDefaultAsync(e => e.Id == request.Id, token);
            if (entity is null)
            {
                throw new ArgumentException();
            }

            return _mapper.Map<ProductDetailsVm>(entity);
        }
    }
}
