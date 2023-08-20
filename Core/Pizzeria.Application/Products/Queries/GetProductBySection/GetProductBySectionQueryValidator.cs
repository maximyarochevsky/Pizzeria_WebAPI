using FluentValidation;

namespace Pizzeria.Application.Products.Queries.GetProductBySection;

public class GetProductBySectionQueryValidator : AbstractValidator<GetProductBySectionQuery>
{
    public GetProductBySectionQueryValidator()
    {
        RuleFor(x => x.SectionId).NotEqual(Guid.Empty);
    }
}
