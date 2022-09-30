using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Specification;
using RentX.Services.Specifications;
using Swashbuckle.AspNetCore.Annotations;

namespace RentX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        private readonly ISpeficicationService speficicationService;

        public SpecificationController(ISpeficicationService speficicationService)
        {
            this.speficicationService = speficicationService;
        }

        #region AddSpecificationAsync
        [SwaggerOperation(Summary = "Add a new specification", Description = "it's necessary to be logged in")]
        [SwaggerResponse(201, "New specification created")]
        [SwaggerResponse(400, "Invalid Name/Description, please try again", typeof(ServiceResponse<string>))]
        [SwaggerResponse(202, "That specification already exists", typeof(ServiceResponse<string>))]
        [HttpPost]
        public ActionResult<ServiceResponse<GetSpecificationDto>> AddSpecificationAsync(AddSpecificationDto newSpecification)
        {
            var res = speficicationService.AddSpecificationAsync(newSpecification);

            if (res.Message.Contains("Invalid Name/Description, please try again")) return BadRequest(res);
            if (res.Message.Contains("That specification already exists")) return Accepted(res);

            return res.Success is true ? Ok(res) : BadRequest(res);
        }
        #endregion
    }
}
