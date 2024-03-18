using AutoMapper;

using cleanArchMvc.Application.DTOs;
using cleanArchMvc.Application.Interfaces;
using cleanArchMvc.Application.Products.Commands;
using cleanArchMvc.Application.Products.Queries;

using MediatR;

namespace cleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task AddAsync(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);

            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int? id)
        {
            var productQuery = new GetProductByIdQuery(id.Value);

            if (productQuery == null)
                throw new ApplicationException("Entity could not be loaded.");

            var result = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productQuery = new GetProductsQuery();

            if (productQuery == null)
                throw new ApplicationException("Entity could not be loaded.");

            var result = await _mediator.Send(productQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
                throw new ApplicationException("Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);

            await _mediator.Send(productUpdateCommand);
        }
    }
}
