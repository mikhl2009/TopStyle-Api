using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;
using AutoMapper;

namespace TopStyle_Api.Domain.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        
        }
    }
}
