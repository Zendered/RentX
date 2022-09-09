using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentX.Dtos.Category;
using RentX.Models;

namespace RentX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<Category> ShowCategory(GetCategoryDto category)
        {
            var res = _mapper.Map<Category>(category);
            return res;
        }
    }
}
