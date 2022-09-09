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
                if (string.IsNullOrWhiteSpace(newCategory.ImageName))
                {
                    res.Data = null;
                    res.Succes = false;
                    res.Message = "Invalid Data, please try again";
                    return res;
                }

                //var exists = await CategoryContext.Categories.FirstOrDefaultAsync(c => c.Id == ) // implementar (GetUserId)

                var category = Mapper.Map<Category>(newCategory);
                res.Data = Mapper.Map<GetCategoryDto>(category);

                await CategoryContext.Categories.AddAsync(category);
                await CategoryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                res.Succes = false;
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

                if (category is null)
                {
                    res.Data = null;
                    res.Succes = false;
                    res.Message = "Category not found";
                    return res;
                }

                res.Data = Mapper.Map<GetCategoryDto>(category);
            }
            catch (Exception ex)
            {

                res.Succes = false;
                res.Message = ex.Message;
            }
            return res;
        }
    }
}
