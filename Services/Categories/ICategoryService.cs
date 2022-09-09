using RentX.Dtos.Category;
using RentX.Models;

namespace RentX.Services.Categories
{
    public interface ICategoryService
    {
        public Task<ServiceResponse<GetCategoryDto>> GetCategoryByIdAsync(Guid id);
        public Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategoriesAsync();
        public Task<ServiceResponse<GetCategoryDto>> AddCategoryAsync(AddCategoryDto category);
        public Task<ServiceResponse<GetCategoryDto>> RemoveCategoryAsync(Guid id);
    }
}
