using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Car;
using RentX.Services.Cars;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpGet("allcars")]
        public async Task<ActionResult<ServiceResponse<List<GetCarDto>>>> GetAllCarsAsync()
        {
            var res = await carService.GetAllCarsAsync();

            return res.Data is not null ? Ok(res) : BadRequest(res);
        }

        #region AddCar
        [SwaggerOperation(Summary = "Add a new car", Description = "it's necessary to be logged in")]
        [SwaggerResponse(201, "New car added", typeof(ServiceResponse<GetCarDto>))]
        [SwaggerResponse(400, "License plate already exists", typeof(ServiceResponse<string>))]
        [SwaggerResponse(404, "Category does not exists", typeof(ServiceResponse<string>))]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> AddCar(AddCarDto car)
        {
            var res = await carService.AddCarAsync(car);

            if (res.Message.Contains("License plate already exists"))
            {
                BadRequest(res);
            }

            if (res.Message.Contains("Category does not exists"))
            {
                NotFound(res);
            }

            return res.Data is not null ? CreatedAtAction(nameof(GetCarById), new { CarId = res.Data.Id }, res) : BadRequest(res);
        }
        #endregion

        #region AddSpecification
        [SwaggerOperation(Summary = "Add car specification", Description = "it's necessary to be logged in")]
        [SwaggerResponse(201, "Specification added", typeof(ServiceResponse<GetCarDto>))]
        [SwaggerResponse(404, "car not found/Specification not found", typeof(ServiceResponse<string>))]
        [HttpPost("{carId}")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> AddSpecificationAsync(Guid carId, [FromForm] Guid carSpecificationId)
        {
            var res = await carService.AddSpecificationAsync(carId, carSpecificationId);

            if (res.Message.Contains("Car not found") ||
                res.Message.Contains("Specification not found"))
                return NotFound(res);

            return res.Data is not null ?
                CreatedAtAction(nameof(GetCarById), new { CarId = res.Data.Id }, res) :
                BadRequest(res);
        }
        #endregion

        #region GetCarById
        [SwaggerOperation(Summary = "Get a car by his id", Description = "it's necessary to be logged in")]
        [SwaggerResponse(200, "Success", typeof(ServiceResponse<GetCarDto>))]
        [SwaggerResponse(404, "Car not found", typeof(ServiceResponse<string>))]
        [HttpGet("{CarId}")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> GetCarById(Guid CarId)
        {
            var res = await carService.GetCarByIdAsync(CarId);

            if (res.Message.Contains("Car not found"))
            {
                NotFound(res);
            }

            return res.Data is not null ? Ok(res) : BadRequest(res);
        }
        #endregion

        #region GetAvailableByIdCars
        [SwaggerOperation(Summary = "Get a car by his id", Description = "it's necessary to be logged in")]
        [SwaggerResponse(204, "There is no cars available right now", typeof(ServiceResponse<GetCarDto>))]
        [SwaggerResponse(404, "There is no cars with this category id", typeof(ServiceResponse<string>))]
        [HttpGet("available-by-id/{categoryId}")]
        public ActionResult<ServiceResponse<GetCarDto>> GetAvailableByIdCars(Guid categoryId)
        {
            var res = carService.GetAllCarsAvailableAsync(categoryId);

            if (res.Message.Contains("There is no cars available right now"))
            {
                NoContent();
            }

            if (res.Message.Contains("There is no cars with this category id"))
            {
                NotFound(res);
            }

            return res.Data is not null ? Ok(res) : BadRequest(res);
        }
        #endregion

        #region GetAvailableByBrandCars
        [SwaggerOperation(Summary = "Get a car by his brand", Description = "it's necessary to be logged in")]
        [SwaggerResponse(204, "There is no cars available right now")]
        [SwaggerResponse(404, "There is no cars with this brand", typeof(ServiceResponse<string>))]
        [HttpGet("available-by-brand/{brand}")]
        public ActionResult<ServiceResponse<GetCarDto>> GetAvailableByBrandCars(string brand)
        {
            var res = carService.GetAllCarsAvailableAsync(brand);

            if (res.Message.Contains("There is no cars available right now")) return NoContent();

            if (res.Message.Contains("There is no cars with this brand")) return NotFound(res);

            return res.Success ? Ok(res) : BadRequest(res);
        }
        #endregion

        #region RemoveCar
        [SwaggerOperation(Summary = "Remove a car", Description = "it's necessary to be logged in")]
        [SwaggerResponse(200, "Car deleted", typeof(ServiceResponse<GetCarDto>))]
        [SwaggerResponse(404, "Car not found", typeof(ServiceResponse<string>))]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> RemoveCar(Guid id)
        {
            var res = await carService.RemoveCarAsync(id);

            return res.Data is not null ? Ok(res) : BadRequest(res);
        }
        #endregion
    }
}
