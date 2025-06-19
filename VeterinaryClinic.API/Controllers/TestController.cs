using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.BLL.Exceptions;

namespace VeterinaryClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("throw-bad")]
        public IActionResult ThrowBad()
        {
            throw new ArgumentException("Text to check the 400 Bad Request");
        }

        [HttpGet("throw-notfound")]
        public IActionResult ThrowNotFound()
        {
            throw new NotFoundException("Test 404 Not Found");
        }

        [HttpGet("throw-error")]
        public IActionResult ThrowError()
        {
            throw new Exception("Test 500 Internal Server Error");
        }
    }

}
