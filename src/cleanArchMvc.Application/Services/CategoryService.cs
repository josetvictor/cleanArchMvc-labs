using AutoMapper;

using cleanArchMvc.Application.DTOs;
using cleanArchMvc.Application.Interfaces;
using cleanArchMvc.Domain.Entities;
using cleanArchMvc.Domain.Interfaces;

namespace cleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _repository.CreateAsync(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _repository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int? id)
        {
            var categoriesEntity = await _repository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoriesEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var categoryEntity = _repository.GetCategoryByIdAsync(id).Result;
            await _repository.DeleteAsync(categoryEntity);
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _repository.UpdateAsync(categoryEntity);
        }
    }
}
