using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public async Task<IActionResult> Test()
        {
            return Ok("OK");
        }
    }
}