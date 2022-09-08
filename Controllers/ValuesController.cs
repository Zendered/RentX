using Microsoft.AspNetCore.Mvc;

namespace RentX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "test1";
        }
    }
}
