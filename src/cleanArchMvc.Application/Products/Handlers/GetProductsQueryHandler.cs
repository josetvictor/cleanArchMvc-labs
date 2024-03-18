using cleanArchMvc.Application.Products.Queries;
using cleanArchMvc.Domain.Entities;
using cleanArchMvc.Domain.Interfaces;

using MediatR;

namespace cleanArchMvc.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductsAsync();
        }
    }
}
