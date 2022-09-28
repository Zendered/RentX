using RentX.Dtos.Specification;

namespace RentX.Services.Specifications
{
    public interface ISpeficicationService
    {
        public ServiceResponse<GetSpecificationDto> AddSpecificationAsync(AddSpecificationDto newSpecification);
    }
}
