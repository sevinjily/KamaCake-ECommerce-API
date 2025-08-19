using AutoMapper;
using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Domain.Entities;

namespace KamaCake.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Cake, UpdateCakeDTO>().ReverseMap();
            CreateMap<Cake, CreateCakeDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();


        }
    }
}
