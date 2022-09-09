using RentX.Dtos.Category;
using RentX.Models;

namespace RentX.Services.Category
{
    public interface ICategoryService
    {
        public Task<ServiceResponse<GetCategoryDto>> GetCategoryByIdAsync(GetCategoryDto category);
        public Task<ServiceResponse<GetCategoryDto>> CreateCategoryIdAsync(CreateCategoryDto category);
    }
}
