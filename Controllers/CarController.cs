using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Car;
using RentX.Exceptions;
using RentX.Services.Cars;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> AddCar(AddCarDto car)
        {
            var res = await carService.AddCarAsync(car);
            var error = new ServiceResponseException<GetCarDto>(null, "Invalid data. Please try again");

            return res.Data is not null ? Ok(res) : BadRequest(error);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCarDto>>>> GetAllCars()
        {
            var res = await carService.GetAllCarAsync();
            var error = new ServiceResponseException<GetCarDto>(null, "Something went wrong. Try again later");

            return res.Data is not null ? Ok(res) : BadRequest(error);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> GetCarById(Guid id)
        {
            var res = await carService.GetCarByIdAsync(id);
            var error = new ServiceResponseException<GetCarDto>(null, "Car not found");

            return res.Data is not null ? Ok(res) : BadRequest(error);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> RemoveCar(Guid id)
        {
            var res = await carService.RemoveCarAsync(id);
            var error = new ServiceResponseException<GetCarDto>(null, "Car not found");

            return res.Data is not null ? Ok(res) : BadRequest(error);
        }
    }
}
