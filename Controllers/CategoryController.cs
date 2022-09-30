using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Category;
using RentX.Services.Categories;
using Swashbuckle.AspNetCore.Annotations;

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

        #region AddCategoryAsync
        [SwaggerOperation(Summary = "Add a new category", Description = "it's necessary to be logged in")]
        [SwaggerResponse(201, "New category created")]
        [SwaggerResponse(400, "Invalid Name/Description, please try again", typeof(ServiceResponse<string>))]
        [SwaggerResponse(202, "That category already exists", typeof(ServiceResponse<string>))]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> AddCategoryAsync(AddCategoryDto category)
        {
            var res = await categoryService.AddCategoryAsync(category);

            if (res.Message.Contains("That category already exists")) return Accepted(res);

            return res.Data is not null ?
                CreatedAtAction(
                    nameof(GetCategoryById),
                    new { categoryId = res.Data.Id },
                    res
                    ) :
                BadRequest(res);
        }
        #endregion

        #region UploadCSVFileAsync
        [SwaggerOperation(Summary = "upload csv file and add new categories", Description = "it's necessary to be logged in")]
        [SwaggerResponse(204, "File uploaded successfully")]
        [SwaggerResponse(400, "Bad Request", typeof(ServiceResponse<string>))]
        [HttpPost("category-csv")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> UploadCSVFileAsync(IFormFile category)
        {
            var res = await categoryService.AddCategoryCSVFileAsync(category);

            return res.Success ? NoContent() : BadRequest(res);
        }
        #endregion

        #region GetCategoryById
        [SwaggerOperation(Summary = "Get category by his id", Description = "it's necessary to be logged in")]
        [SwaggerResponse(200, "Success", typeof(ServiceResponse<string>))]
        [SwaggerResponse(404, "Category not found", typeof(ServiceResponse<string>))]
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> GetCategoryById(Guid categoryId)
        {
            var res = await categoryService.GetCategoryByIdAsync(categoryId);
            return res.Data is not null ?
                Ok(res) :
                BadRequest(res);
        }
        #endregion

        #region GetAllCategoriesAsync
        [SwaggerOperation(Summary = "Get category categories", Description = "it's necessary to be logged in")]
        [SwaggerResponse(200, "Success", typeof(ServiceResponse<string>))]
        [SwaggerResponse(400, "Bad Request 400", typeof(ServiceResponse<string>))]
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> GetAllCategoriesAsync()
        {
            var res = await categoryService.GetAllCategoriesAsync();
            return res.Success ?
                Ok(res) :
                BadRequest(res);
        }
        #endregion

        #region RemoveCategoryAsync
        [SwaggerOperation(Summary = "Remove a category", Description = "it's necessary to be logged in")]
        [SwaggerResponse(200, "Category deleted", typeof(ServiceResponse<string>))]
        [SwaggerResponse(404, "Bad Request 400", typeof(ServiceResponse<string>))]
        [SwaggerResponse(404, "Category not found", typeof(ServiceResponse<string>))]
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetCategoryDto>>> RemoveCategoryAsync(Guid id)
        {
            var res = await categoryService.RemoveCategoryAsync(id);
            if (res.Message.Contains("Category not found")) return NotFound(res);

            return res.Success ?
                Ok(res) :
                BadRequest(res);
        }
        #endregion

        #region GetCategoryCSVFile
        //[HttpGet("category-csv-file")]
        //public ActionResult<ServiceResponse<GetCategoryDto>> GetCategoryCSVFile(string fileName)
        //{
        //    var res = categoryService.GetCategoryCSVFile(fileName);
        //    var error = new ServiceResponseException<GetCategoryDto>(
        //        null, "Invalid Name/Description, please try again"
        //        );

        //    return Ok(res);
        //}
        #endregion
    }
}
