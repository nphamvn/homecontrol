using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace HomeControl.Api.Hubs
{
    public class AirConditionerHub : Hub
    {
        private readonly AirConditioner.AirConditionerClient _client;
        private readonly ILogger<AirConditionerHub> _logger;

        public AirConditionerHub(AirConditioner.AirConditionerClient client, ILogger<AirConditionerHub> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task TurnOnCooler()
        {
            var reply = await _client.TurnOnCoolerAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("AirConditionerStateChanged", reply);
        }
        public async Task TurnOnHeater()
        {
            var reply = await _client.TurnOnHeaterAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("AirConditionerStateChanged", reply);
        }
        public async Task IncreaseTemperature()
        {
            var reply = await _client.IncreaseTemperatureAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("AirConditionerStateChanged", reply);
        }
        public async Task DecreaseTemperature()
        {
            var reply = await _client.DecreaseTemperatureAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("AirConditionerStateChanged", reply);
        }
    }
}