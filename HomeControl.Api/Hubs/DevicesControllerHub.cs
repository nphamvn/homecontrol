using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace HomeControl.Api.Hubs
{
    public class DevicesControllerHub : Hub
    {
        private readonly Light.LightClient _lightClient;
        private readonly AirConditioner.AirConditionerClient _airConditionerClient;
        private readonly EnvironmentSensor.EnvironmentSensorClient _environmentSensorClient;
        private readonly ILogger<DevicesControllerHub> _logger;

        public DevicesControllerHub(Light.LightClient lightClient,
            AirConditioner.AirConditionerClient airConditionerClient,
            EnvironmentSensor.EnvironmentSensorClient environmentSensorClient,
            ILogger<DevicesControllerHub> logger
            )
        {
            _lightClient = lightClient;
            _airConditionerClient = airConditionerClient;
            _environmentSensorClient = environmentSensorClient;
            _logger = logger;
        }

        //Light
        public async Task TurnOnLight()
        {
            var reply = await _lightClient.TurnOnLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("LightStateChanged", "ON");
        }
        public async Task TurnOffLight()
        {
            var reply = await _lightClient.TurnOffLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("LightStateChanged", "ON");
        }
        public async Task BrightenLight()
        {
            var reply = await _lightClient.BrightenLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("LightStateChanged", "ON");
        }
        public async Task DimLight()
        {
            var reply = await _lightClient.DimLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("LightStateChanged", "ON");
        }

        //Air Conditioner
        public async Task TurnOnCooler()
        {
            var reply = await _airConditionerClient.TurnOnCoolerAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("AirConditionerStateChanged", reply);
        }
        public async Task TurnOnHeater()
        {
            var reply = await _airConditionerClient.TurnOnHeaterAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("AirConditionerStateChanged", reply);
        }
        public async Task IncreaseTemperature()
        {
            var reply = await _airConditionerClient.IncreaseTemperatureAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("AirConditionerStateChanged", reply);
        }
        public async Task DecreaseTemperature()
        {
            var reply = await _airConditionerClient.DecreaseTemperatureAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("AirConditionerStateChanged", reply);
        }
    }
}