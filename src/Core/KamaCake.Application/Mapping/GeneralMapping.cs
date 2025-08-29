using AutoMapper;
using KamaCake.Application.DTOs.AuthDTOs;
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
            CreateMap<Cake, GetCakeDTO>().ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category,GetAllCategoryForUserDTO>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDTO>().ReverseMap();

            CreateMap<User, RegisterDTO>().ReverseMap();
            

        }
    }
}
