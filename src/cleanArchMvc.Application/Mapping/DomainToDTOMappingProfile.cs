using AutoMapper;

using cleanArchMvc.Application.DTOs;
using cleanArchMvc.Domain.Entities;

namespace cleanArchMvc.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
