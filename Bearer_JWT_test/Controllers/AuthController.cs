using Bearer_JWT_test.Endpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bearer_JWT_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        JwtOptions jwtOptions;
        public AuthController(JwtOptions jwtOptions)
        {
            this.jwtOptions = jwtOptions;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello World!");
        }
        [Route("[action]")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult PublicPage()
        {
            return Ok("Public Hello World!");
        }
        [Route("[action]")]
        [Authorize]
        [HttpGet]
        public IActionResult PrivatePage()
        {
            return Ok("Private Hello World!");
        }
        [Route("[action]")]
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> TokenConnectPage([FromForm] FormAuth formAuth)
        {
            try
            {
                return Ok(await TokenEndpoint.Connect(HttpContext, jwtOptions));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
            }

            return BadRequest();
        }

    }
    public class FormAuth
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
