using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentX.Data;
using RentX.Dtos.Category;
using RentX.Models;

namespace RentX.Services.Categories
{
    public record CategoryService(DataContext CategoryContext, IMapper Mapper) : ICategoryService
    {
        public async Task<ServiceResponse<GetCategoryDto>> AddCategoryAsync(AddCategoryDto newCategory)
        {
            var res = new ServiceResponse<GetCategoryDto>();

            try
            {
                if (string.IsNullOrEmpty(newCategory.Name) || string.IsNullOrEmpty(newCategory.Description)) return res;

                var category = Mapper.Map<Category>(newCategory);
                res.Data = Mapper.Map<GetCategoryDto>(category);
                res.Message = "Category created";

                await CategoryContext.Categories.AddAsync(category);
                await CategoryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategoriesAsync()
        {
            var res = new ServiceResponse<List<GetCategoryDto>>();

            try
            {
                var category = await CategoryContext.Categories.ToListAsync();
                res.Data = Mapper.Map<List<GetCategoryDto>>(category);
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<ServiceResponse<GetCategoryDto>> GetCategoryByIdAsync(Guid id)
        {
            var res = new ServiceResponse<GetCategoryDto>();

            try
            {
                var category = await CategoryContext.Categories.FirstOrDefaultAsync(cat => cat.Id == id);

                if (category is null) return res;

                res.Data = Mapper.Map<GetCategoryDto>(category);
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<ServiceResponse<GetCategoryDto>> RemoveCategoryAsync(Guid id)
        {
            var res = new ServiceResponse<GetCategoryDto>();

            try
            {
                var category = await CategoryContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

                if (category is null) return res;

                CategoryContext.Remove(category);
                await CategoryContext.SaveChangesAsync();

                res.Data = Mapper.Map<GetCategoryDto>(category);
                res.Message = "Category deleted";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }
    }
}
