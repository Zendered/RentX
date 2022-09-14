using RentX.Dtos.Category;

namespace RentX.Services.Categories
{
    public interface ICategoryService
    {
        public Task<ServiceResponse<GetCategoryDto>> GetCategoryByIdAsync(Guid id);
        public Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategoriesAsync();
        //public Task<ServiceResponse<GetCategoryDto>> AddCategoryAsync(AddCategoryDto category);
        public Task<ServiceResponse<GetCategoryDto>> RemoveCategoryAsync(Guid id);
        public Task<ServiceResponse<GetCategoryDto>> AddCategoryCSVFileAsync(IFormFile categoryFile);
        public Task<ServiceResponse<GetCategoryDto>> AddCategoryAsync(List<AddCategoryDto> category);
        public ServiceResponse<List<GetCategoryDto>> GetCategoryCSVFile(string fileName);

    }
}
