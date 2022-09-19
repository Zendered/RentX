using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Category;
using RentX.Exceptions;
using RentX.Services.Categories;

namespace RentX.Controllers
{
    [Authorize]
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
            var error = new ServiceResponseException<GetCategoryDto>(
                null, "Invalid Name/Description, please try again"
                );

            return res.Data is not null ?
                Ok(res) :
                BadRequest(error);
        }

        [HttpGet("All categories")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> GetAllCategoriesAsync()
        {
            var res = await categoryService.GetAllCategoriesAsync();
            return res.Success is false ?
             BadRequest(res) :
            Ok(res);
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

        [HttpPost("add-category-csv")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> UploadCSVFileAsync(IFormFile category)
        {
            var res = await categoryService.AddCategoryCSVFileAsync(category);
            var error = new ServiceResponseException<GetCategoryDto>(
                null, "Invalid Name/Description, please try again"
                );

            return Ok(res);
        }

        [HttpGet("get-category-csv")]
        public ActionResult<ServiceResponse<GetCategoryDto>> GetCategoryCSVFile(string fileName)
        {
            var res = categoryService.GetCategoryCSVFile(fileName);
            var error = new ServiceResponseException<GetCategoryDto>(
                null, "Invalid Name/Description, please try again"
                );

            return Ok(res);
        }
    }
}
