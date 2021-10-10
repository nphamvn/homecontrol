using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LightController : ControllerBase
    {
        private readonly Light.LightClient _client;

        public LightController(Light.LightClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Test()
        {
            var result = await _client.GetStateAsync(new Google.Protobuf.WellKnownTypes.Empty());
            return Ok(result);
        }
    }
}