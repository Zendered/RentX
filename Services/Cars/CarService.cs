using AutoMapper;
using RentX.Data;
using RentX.Dtos.Car;

namespace RentX.Services.Cars
{
    public class CarService : ICarService
    {
        private readonly DataContext carContext;
        private readonly IMapper mapper;

        public CarService(DataContext carContext, IMapper mapper)
        {
            this.carContext = carContext;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetCarDto>> AddCarAsync(AddCarDto newCar)
        {
            var res = new ServiceResponse<GetCarDto>();

            try
            {
                var carName = string.IsNullOrWhiteSpace(newCar.Name);
                var carDescription = string.IsNullOrWhiteSpace(newCar.Description);
                var carLicensePlate = string.IsNullOrWhiteSpace(newCar.LicensePlate);
                var carBrand = string.IsNullOrWhiteSpace(newCar.Brand);

                if (carName || carDescription || carLicensePlate || carBrand) return res;

                var car = mapper.Map<Car>(newCar);
                res.Data = mapper.Map<GetCarDto>(car);

                carContext.Add(car);
                await carContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public Task<ServiceResponse<List<GetCarDto>>> GetAllCarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCarDto>> GetCarByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCarDto>> RemoveCarAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
