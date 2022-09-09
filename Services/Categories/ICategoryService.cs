using RentX.Dtos.Category;
using RentX.Models;

namespace RentX.Services.Categories
{
    public interface ICategoryService
    {
        public Task<ServiceResponse<GetCategoryDto>> GetCategoryByIdAsync(Guid id);
        public Task<ServiceResponse<GetCategoryDto>> AddCategoryAsync(AddCategoryDto category);
    }
}
