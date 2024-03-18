using cleanArchMvc.Application.Products.Commands;
using cleanArchMvc.Domain.Entities;
using cleanArchMvc.Domain.Interfaces;

using MediatR;

namespace cleanArchMvc.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);

            if (product == null)
                throw new ApplicationException("Error could not be found");
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
                return await _productRepository.UpdateAsync(product);
            }
        }
    }
}
