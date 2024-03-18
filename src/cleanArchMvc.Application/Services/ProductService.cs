using AutoMapper;

using cleanArchMvc.Application.DTOs;
using cleanArchMvc.Application.Interfaces;
using cleanArchMvc.Domain.Entities;
using cleanArchMvc.Domain.Interfaces;

namespace cleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _repository.CreateAsync(productEntity);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int? id)
        {
            var productEntity = await _repository.GetProductByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var productEntity = await _repository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsEntity = await _repository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var productEntity = _repository.GetProductByIdAsync(id).Result;
            await _repository.DeleteAsync(productEntity);
            
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);

            await _repository.UpdateAsync(productEntity);
        }
    }
}
