using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Rental;
using RentX.Services.Rentals;
using Swashbuckle.AspNetCore.Annotations;

namespace RentX.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService service;

        public RentalController(IRentalService service)
        {
            this.service = service;
        }

        #region Make rental
        [SwaggerOperation(Summary = "Make a rent", Description = "it's necessary to be logged in")]
        [SwaggerResponse(201, "Rent made successfully", typeof(ServiceResponse<GetRentalDto>))]
        [SwaggerResponse(400, "User already has a rent", typeof(ServiceResponse<string>))]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetRentalDto>>> MakeRental(AddRentalDto req)
        {
            var res = await service.CreateRentalAsync(req);

            return res.Success ? Ok(res) : BadRequest(res);
        }
        #endregion

        #region Rentals devolution
        [SwaggerOperation(Summary = "rentals devolution", Description = "it's necessary to be logged in")]
        [SwaggerResponse(201, "Rent made successfully", typeof(ServiceResponse<GetRentalDto>))]
        [SwaggerResponse(400, "User already has a rent", typeof(ServiceResponse<string>))]
        [HttpPost("devolution/{rentalId}")]
        public async Task<ActionResult<ServiceResponse<GetRentalDto>>> RentalsDevolution(Guid rentalId)
        {
            var req = new RentalsDevolutionDto()
            {
                Id = rentalId,
            };

            var res = await service.DevolutionRentalAsync(req);

            return res.Success ? Ok(res) : BadRequest(res);
        }
        #endregion
    }
}
