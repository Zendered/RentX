using RentX.Dtos.Car;

namespace RentX.Services.Cars
{
    public interface ICarService
    {
        Task<ServiceResponse<GetCarDto>> AddCarAsync(AddCarDto car);
        Task<ServiceResponse<GetCarDto>> AddSpecificationAsync(Guid carsId, Guid carSpecificationId);

        ServiceResponse<List<GetCarDto>> GetAllCarsAvailableAsync(string? brand);
        ServiceResponse<List<GetCarDto>> GetAllCarsAvailableAsync(Guid? categoryId);
        Task<ServiceResponse<List<GetCarDto>>> GetAllCarsAsync();

        Task<ServiceResponse<GetCarDto>> GetCarByIdAsync(Guid id);
        Task<ServiceResponse<GetCarDto>> GetCarByLicensePlateAsync(string licensePlate);

        Task<ServiceResponse<GetCarDto>> updateAvailable(Guid id, bool available = true);
        Task<ServiceResponse<GetCarDto>> RemoveCarAsync(Guid id, bool available = true);
    }
}
