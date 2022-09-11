using AutoMapper;
using RentX.Dtos.Car;
using RentX.Dtos.Category;

namespace RentX
{
    public class AutoMapperProfille : Profile
    {
        public AutoMapperProfille()
        {
            CreateMap<GetCategoryDto, Category>();
            CreateMap<AddCategoryDto, Category>();

            CreateMap<GetCarDto, Car>();
            CreateMap<AddCarDto, Car>();

            CreateMap<Category, GetCategoryDto>();

            CreateMap<Car, GetCarDto>();
        }
    }
}
