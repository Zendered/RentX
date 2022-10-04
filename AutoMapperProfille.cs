using AutoMapper;
using RentX.Dtos.Car;
using RentX.Dtos.Category;
using RentX.Dtos.Rental;
using RentX.Dtos.Specification;

namespace RentX
{
    public class AutoMapperProfille : Profile
    {
        public AutoMapperProfille()
        {
            CreateMap<GetCategoryDto, Category>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<AddCategoryDto, GetCategoryDto>();

            CreateMap<GetCarDto, Car>();
            CreateMap<AddCarDto, Car>();

            CreateMap<GetSpecificationDto, Specification>();
            CreateMap<AddSpecificationDto, Specification>();
            CreateMap<AddCarSpecificationDto, Specification>();

            CreateMap<AddRentalDto, Rental>();
            CreateMap<GetRentalDto, Rental>();
            CreateMap<GetRentalDto, AddRentalDto>();

            CreateMap<Specification, GetSpecificationDto>();

            CreateMap<Category, GetCategoryDto>();

            CreateMap<Car, GetCarDto>();

            CreateMap<Rental, GetRentalDto>();
        }
    }
}
