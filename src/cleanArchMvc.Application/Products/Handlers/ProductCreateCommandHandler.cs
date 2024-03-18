using cleanArchMvc.Application.Products.Commands;
using cleanArchMvc.Domain.Entities;
using cleanArchMvc.Domain.Interfaces;

using MediatR;

namespace cleanArchMvc.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {

            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

            if (product == null)
                throw new ApplicationException("Error creating entity");
            else
            {
                product.CategoryId = request.CategoryId;
                return await _productRepository.CreateAsync(product);
            }
        }
    }
}
