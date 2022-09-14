using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Specification;
using RentX.Services.Specifications;

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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetSpecificationDto>>> AddCSVSpecification(List<AddSpecificationDto> newSpecification)
        {
            return Ok(await speficicationService.AddSpecificationAsync(newSpecification));
        }

        [HttpPost("Upload-CSV-File")]
        public async Task<ActionResult<ServiceResponse<GetSpecificationDto>>> AddSpecificationCSVFile(IFormFile specificationFile)
        {
            return Ok(await speficicationService.AddSpecificationCSVFileAsync(specificationFile));
        }
    }
}
