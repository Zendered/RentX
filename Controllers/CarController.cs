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
        public async Task<ActionResult<ServiceResponse<string>>> AddCar(AddCarDto car)
        {
            var res = await carService.AddCarAsync(car);
            var error = new ServiceResponseException<GetCarDto>(null, "Invalid data. Please try again");

            return res.Data is not null ? Ok(res) : BadRequest(error);
        }
    }
}
