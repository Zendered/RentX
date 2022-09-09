using AutoMapper;
using RentX.Dtos.Category;
using RentX.Models;

namespace RentX
{
    public class AutoMapperProfille : Profile
    {
        public AutoMapperProfille()
        {
            CreateMap<GetCategoryDto, Category>();
            CreateMap<AddCategoryDto, Category>();

            CreateMap<Category, GetCategoryDto>();
        }
    }
}
