using AutoMapper;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Products.Queries.ViewModels;

public class ListProductsVm
{
    public List<ProductDetailsVm> ListProducts { get; set; }
}

