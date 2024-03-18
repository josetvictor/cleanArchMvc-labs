using cleanArchMvc.Application.Products.Commands;
using cleanArchMvc.Domain.Entities;
using cleanArchMvc.Domain.Interfaces;

using MediatR;

namespace cleanArchMvc.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _repository;
        public ProductRemoveCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductByIdAsync(request.Id);

            if (product == null)
                throw new ApplicationException("Error could not be found");
            else
            {
                var result = await _repository.DeleteAsync(product);
                return result;
            }
        }
    }
}
