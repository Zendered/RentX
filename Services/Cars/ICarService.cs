using RentX.Dtos.Car;
using RentX.Models;

namespace RentX.Services.Cars
{
    public interface ICarService
    {
        public Task<ServiceResponse<GetCarDto>> GetCarByIdAsync(Guid id);
        public Task<ServiceResponse<List<GetCarDto>>> GetAllCarAsync();
        public Task<ServiceResponse<GetCarDto>> AddCarAsync(AddCarDto car);
        public Task<ServiceResponse<GetCarDto>> RemoveCarAsync(Guid id);
    }
}
