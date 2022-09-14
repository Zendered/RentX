using RentX.Dtos.Specification;

namespace RentX.Services.Specifications
{
    public interface ISpeficicationService
    {
        public Task<ServiceResponse<GetSpecificationDto>> AddSpecificationCSVFileAsync(IFormFile specificationFile);
        public Task<ServiceResponse<GetSpecificationDto>> AddSpecificationAsync(List<AddSpecificationDto> category);
    }
}
