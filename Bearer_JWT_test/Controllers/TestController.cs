using Microsoft.AspNetCore.Mvc;

namespace Bearer_JWT_test.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        [Route("[action]")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
