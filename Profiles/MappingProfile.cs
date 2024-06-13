using AutoMapper;
using LinqDatabasePractice.DTO;
using LinqDatabasePractice.Models;

namespace LinqDatabasePractice.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
