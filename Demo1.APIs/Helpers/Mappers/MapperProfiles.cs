using AutoMapper;
using Demo1.APIs.Helpers.DTOs;
using Demo1.Core.Entities;

namespace Demo1.APIs.Helpers.Mappers
{
	public class MapperProfiles : Profile
	{
        public MapperProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Brand, obj => obj.MapFrom(product => product.ProductBrand.Name))
                .ForMember(dto => dto.Type, obj => obj.MapFrom(product => product.ProductType.Name));
        }
    }
}
