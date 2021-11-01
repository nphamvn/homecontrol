using System.Threading.Tasks;
using HomeControl.Api.Models;
using HomeControl.Api.Tests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeControl.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        public async Task<IActionResult> Test()
        {
            return Ok(new RequestResponse<bool>
            {
                Success = true,
                Data = _testService.Initialized
            });
        }
    }
}