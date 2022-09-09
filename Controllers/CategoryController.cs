using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Category;
using RentX.Models;
using RentX.Services.Categories;

namespace RentX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> GetCategoryById(Guid id)
        {
            var res = await categoryService.GetCategoryByIdAsync(id);
            return res.Data is not null ?
                Ok(res) :
                BadRequest(res);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> AddCategoryAsync(AddCategoryDto category)
        {
            var res = await categoryService.AddCategoryAsync(category);
            return res.Data is not null ?
                Ok(res) :
                BadRequest(res);
        }

        [HttpGet("All categories")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> GetAllCategoriesAsync()
        {
            var res = await categoryService.GetAllCategoriesAsync();
            return res.Data is not null ?
                Ok(res) :
                BadRequest(res);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> RemoveCategoryAsync(Guid id)
        {
            var res = await categoryService.RemoveCategoryAsync(id);
            return res.Data is not null ?
                Ok(res) :
                BadRequest(res);
        }
    }
}
