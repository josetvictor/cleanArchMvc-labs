using cleanArchMvc.Domain.Entities;

using MediatR;

namespace cleanArchMvc.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
