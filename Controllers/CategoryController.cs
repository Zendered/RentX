using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Category;
using RentX.Exceptions;
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
            var error = new ServiceResponseException<GetCategoryDto>(
                        null,
                        "Category not found");

            return res.Data is not null ?
                Ok(res) :
                BadRequest(error);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> AddCategoryAsync(AddCategoryDto category)
        {
            var res = await categoryService.AddCategoryAsync(category);
            return res.Data is not null ?
                Ok(res) :
                BadRequest(
                    new ServiceResponseException<GetCategoryDto>(
                        null,
                        "Invalid Name/Description, please try again")
                    );
        }

        [HttpGet("All categories")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> GetAllCategoriesAsync()
        {
            var res = await categoryService.GetAllCategoriesAsync();
            return res.Success is false ?
            Ok(res) :
            BadRequest(res);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> RemoveCategoryAsync(Guid id)
        {
            var res = await categoryService.RemoveCategoryAsync(id);
            var error = new ServiceResponseException<GetCategoryDto>(
                        null,
                        "Category not found");

            return res.Data is not null ?
                Ok(res) :
                BadRequest(error);
        }
    }
}
