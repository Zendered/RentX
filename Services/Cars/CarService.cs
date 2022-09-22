﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

                if (carName || carDescription || carLicensePlate || carBrand)
                {
                    res.Data = null;
                    res.Message = "Something went wrong. Try again later";
                    res.Success = false;
                    return res;
                };

                var carAlreadyExists = await carContext.Cars.AnyAsync(c => c.LicensePlate == newCar.LicensePlate);
                if (carAlreadyExists)
                {
                    res.Success = false;
                    res.Message = "License plate already exists";
                    res.Data = null;
                    return res;
                }

                var categoryExists = await carContext.Categories.AnyAsync(c => c.Id == newCar.CategoryId);
                if (categoryExists is false)
                {
                    res.Success = false;
                    res.Message = "Category does not exists";
                    res.Data = null;
                    return res;
                }

                var car = mapper.Map<Car>(newCar);
                res.Data = mapper.Map<GetCarDto>(car);
                res.Message = "New car added";

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

        public async Task<ServiceResponse<GetCarDto>> GetCarByIdAsync(Guid id)
        {
            var res = new ServiceResponse<GetCarDto>();

            try
            {
                var car = await carContext.Cars
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (car is null)
                {
                    res.Data = null;
                    res.Success = false;
                    res.Message = "Car not found";
                    return res;
                }

                res.Data = mapper.Map<GetCarDto>(car);
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        // Get all car available by category id
        public async Task<ServiceResponse<List<GetCarDto>>> GetAllCarsAvailableAsync(Guid? categoryId)
        {
            var res = new ServiceResponse<List<GetCarDto>>();

            try
            {
                var isAvailable = carContext.Cars.Any(c => c.Available == true);
                if (isAvailable is false)
                {
                    res.Success = false;
                    res.Message = "There is no cars available right now";
                    res.Data = null;
                    return res;
                }

                var car = carContext.Cars.Where(b => b.Available == true).Where(c => c.CategoryId == categoryId);

                if (car.Count() == 0)
                {
                    res.Message = "There is no cars with this category id";
                    return res;
                }

                res.Data = mapper.Map<List<GetCarDto>>(car);
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        // Get all car available by his brand
        public async Task<ServiceResponse<List<GetCarDto>>> GetAllCarsAvailableAsync(string? brand)
        {
            var res = new ServiceResponse<List<GetCarDto>>();

            try
            {
                var isAvailable = carContext.Cars.Any(c => c.Available == true);
                if (isAvailable is false)
                {
                    res.Success = false;
                    res.Message = "There is no cars available right now";
                    res.Data = null;
                    return res;
                }

                var car = carContext.Cars.Where(b => b.Available == true).Where(c => c.Brand == brand);

                if (car.Count() == 0)
                {
                    res.Data = null;
                    res.Message = "There is no cars with this brand";
                    return res;
                }

                res.Data = mapper.Map<List<GetCarDto>>(car);
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public Task<ServiceResponse<GetCarDto>> GetCarByLicensePlateAsync(string licensePlate)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCarDto>> updateAvailable(Guid id, bool available = true)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetCarDto>> RemoveCarAsync(Guid id, bool available = true)
        {
            var res = new ServiceResponse<GetCarDto>();

            try
            {
                var car = await carContext.Cars.FirstOrDefaultAsync(c => c.Id == id);

                if (car is null)
                {
                    res.Success = false;
                    res.Message = "Car not found";
                    res.Data = null;
                    return res;
                };

                carContext.Cars.Remove(car);
                await carContext.SaveChangesAsync();

                res.Data = mapper.Map<GetCarDto>(car);
                res.Message = "Car deleted";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }
        //public async Task<ServiceResponse<List<GetCarDto>>> GetAllCarsAvailableAsync(string? name)
        //{
        //    var res = new ServiceResponse<List<GetCarDto>>();

        //    try
        //    {
        //        var car = carContext.Cars.Where(c => c.Available == true).ToList();
        //        res.Data = mapper.Map<List<GetCarDto>>(car);
        //    }
        //    catch (Exception ex)
        //    {
        //        res.Success = false;
        //        res.Message = ex.Message;
        //    }
        //    return res;
        //}
    }
}
