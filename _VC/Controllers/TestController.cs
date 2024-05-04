using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _VC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {


        [HttpGet("Test1")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public IActionResult Test1()
        {


            return Ok("Good");
        }

        [HttpGet("Test2")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Test2()
        {


            return Ok("Exallent");
        }

    }
}
