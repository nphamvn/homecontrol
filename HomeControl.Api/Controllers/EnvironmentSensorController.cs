using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeControl.Api.Controllers
{
    [ApiController]
    [Route("api/envsensor")]
    public class EnvironmentSensorController : Controller
    {
        private readonly EnvironmentSensor.EnvironmentSensorClient _client;
        private readonly ILogger _logger;

        public EnvironmentSensorController(EnvironmentSensor.EnvironmentSensorClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IActionResult> Get()
        {
            var result = await _client.GetSensorDataAsync(new Google.Protobuf.WellKnownTypes.Empty());
            return Ok(new
            {
                Temperature = result.Temperature,
                Humidity = result.Humindity,
                Time = result.Time
            });
        }
    }
}