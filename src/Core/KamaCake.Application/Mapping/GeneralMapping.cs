using AutoMapper;
using KamaCake.Application.DTOs.AuthDTOs;
using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.DTOs.CartDTOs.CartItemDTO;
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
                CreateMap<Cake, GetCakeDTO>().ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.CategoryName));

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
                CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
                CreateMap<Category,GetAllCategoryForUserDTO>().ReverseMap();
                CreateMap<Category, GetCategoryByIdDTO>().ReverseMap();

                CreateMap<User, RegisterDTO>().ReverseMap();
                
                CreateMap<CreateCartItemDTO, CartItem>()
                .ForMember(dest => dest.CakeId, opt => opt.MapFrom(src => src.CakeId))
                    .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.ToString()))
                    .ReverseMap();

            }
        }
    }
