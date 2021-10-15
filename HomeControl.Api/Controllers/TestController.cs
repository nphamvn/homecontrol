using System.Threading.Tasks;
using HomeControl.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public async Task<IActionResult> Test()
        {
            return Ok(new RequestResponse<string>
            {
                Success = true,
                Data = "Test sucessful"
            });
        }
    }
}