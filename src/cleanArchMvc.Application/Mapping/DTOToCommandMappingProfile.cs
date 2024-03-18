using AutoMapper;

using cleanArchMvc.Application.DTOs;
using cleanArchMvc.Application.Products.Commands;

namespace cleanArchMvc.Application.Mapping
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
