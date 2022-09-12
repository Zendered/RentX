using AutoMapper;
using RentX.Dtos.Car;
using RentX.Dtos.Category;
using RentX.Dtos.Specification;

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

            CreateMap<GetSpecificationDto, Car>();
            CreateMap<AddSpecificationDto, Car>();

            CreateMap<Specification, GetSpecificationDto>();

            CreateMap<Category, GetCategoryDto>();

            CreateMap<Car, GetCarDto>();
        }
    }
}
