
using AutoMapper;
using JWTApi.Data;
using JWTApi.Dto;
using JWTApi.Models;

namespace JWTApi.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // * CreateMap<Source , Target>
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}