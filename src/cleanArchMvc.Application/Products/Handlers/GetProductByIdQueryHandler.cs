using cleanArchMvc.Application.Products.Queries;
using cleanArchMvc.Domain.Entities;
using cleanArchMvc.Domain.Interfaces;

using MediatR;

namespace cleanArchMvc.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repository;
        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductByIdAsync(request.Id);
        }
    }
}
