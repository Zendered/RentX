using RentX.Dtos.Specification;

namespace RentX.Services.Specifications
{
    public interface ISpeficicationService
    {
        public Task<ServiceResponse<GetSpecificationDto>> GetSpecificationByIdAsync(Guid id);
        public Task<ServiceResponse<GetSpecificationDto>> AddSpecificationAsync(List<AddSpecificationDto> category);
    }
}
