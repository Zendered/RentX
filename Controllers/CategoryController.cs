using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Category;
using RentX.Models;
using RentX.Services.Category;

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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> GetCategoryById(GetCategoryDto category)
        {
            var res = await categoryService.GetCategoryByIdAsync(category);
            return res is null ? Ok(res) : BadRequest(res);
        }
    }
}
