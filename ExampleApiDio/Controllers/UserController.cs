using Microsoft.AspNetCore.Mvc;

namespace ExampleApiDio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("GetDateTimeNow")]
        public IActionResult GetDateTime()
        {
            var obj = new
            {
                Date = DateTime.Now.ToLongDateString(),
                Time = DateTime.Now.ToShortTimeString()
            };

           return Ok(obj);
        }

        [HttpGet("Apresentar/{name}")]
        public IActionResult Introduce(
            string name
        )
        {
            var message = $"Hello, my name is {name}";

            return Ok(new {message});
        }
    }
}
