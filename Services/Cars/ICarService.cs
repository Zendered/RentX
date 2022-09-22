﻿using RentX.Dtos.Car;

namespace RentX.Services.Cars
{
    public interface ICarService
    {
        Task<ServiceResponse<GetCarDto>> AddCarAsync(AddCarDto car);
        Task<ServiceResponse<List<GetCarDto>>> GetAllCarsAvailableAsync(string? brand);

        Task<ServiceResponse<List<GetCarDto>>> GetAllCarsAvailableAsync(Guid? categoryId);
        Task<ServiceResponse<GetCarDto>> GetCarByIdAsync(Guid id);
        Task<ServiceResponse<GetCarDto>> GetCarByLicensePlateAsync(string licensePlate);
        Task<ServiceResponse<GetCarDto>> updateAvailable(Guid id, bool available = true);
        Task<ServiceResponse<GetCarDto>> RemoveCarAsync(Guid id, bool available = true);
    }
}
