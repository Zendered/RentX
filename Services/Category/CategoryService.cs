using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentX.Data;
using RentX.Dtos.Category;
using RentX.Models;

namespace RentX.Services.Category
{
    public record CategoryService(DataContext CategoryContext, IMapper Mapper) : ICategoryService
    {

        public async Task<ServiceResponse<GetCategoryDto>> GetCategoryByIdAsync(GetCategoryDto Getcategory)
        {
            var res = new ServiceResponse<GetCategoryDto>();

            try
            {
                var category = await CategoryContext.Categories.FirstOrDefaultAsync(cat => cat.Id == Getcategory.Id);

                if (category == null)
                {
                    res.Data = null;
                    res.Succes = false;
                    res.Message = "deu ruim";
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
