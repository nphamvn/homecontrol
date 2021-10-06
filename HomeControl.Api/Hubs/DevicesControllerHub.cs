using System.Threading.Tasks;
using HomeControl.Api.Messages;
using MassTransit;
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
        private readonly IBus _bus;

        public DevicesControllerHub(Light.LightClient lightClient,
            AirConditioner.AirConditionerClient airConditionerClient,
            EnvironmentSensor.EnvironmentSensorClient environmentSensorClient,
            ILogger<DevicesControllerHub> logger,
            IBus bus)
        {
            _lightClient = lightClient;
            _airConditionerClient = airConditionerClient;
            _environmentSensorClient = environmentSensorClient;
            _logger = logger;
            _bus = bus;
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation("Client connected");
            await Clients.All.SendAsync("Broadcast", "Connected");
        }

        //Environment Sensor
        public async Task GetEnvironmentSensorData()
        {
            var reply = await _environmentSensorClient.GetSensorDataAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var message = new EnvironmentSensorDataChanged
            {
                Temperature = reply.Temperature,
                Humidity = reply.Humindity
            };
            await _bus.Publish(message);
        }
        //Light
        public async Task GetLightState()
        {
            var reply = await _lightClient.GetStateAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var message = new LightStateChanged
            {
                Mode = reply.Mode,
                Brightness = reply.Brightness
            };
            await _bus.Publish(message);
        }
        public async Task TurnOnLight()
        {
            _logger.LogInformation(nameof(TurnOnLight));
            //var reply = await _lightClient.TurnOnLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var reply = new LightReply
            {
                Mode = "ON",
                Brightness = 10
            };
            var message = new LightStateChanged
            {
                Mode = reply.Mode,
                Brightness = reply.Brightness
            };
            await _bus.Publish(message);
        }
        public async Task TurnOffLight()
        {
            var reply = await _lightClient.TurnOffLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var message = new LightStateChanged
            {
                Mode = reply.Mode,
                Brightness = reply.Brightness
            };
            await _bus.Publish(message);
        }
        public async Task BrightenLight()
        {
            var reply = await _lightClient.BrightenLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var message = new LightStateChanged
            {
                Mode = reply.Mode,
                Brightness = reply.Brightness
            };
            await _bus.Publish(message);
        }
        public async Task DimLight()
        {
            var reply = await _lightClient.DimLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var message = new LightStateChanged
            {
                Mode = reply.Mode,
                Brightness = reply.Brightness
            };
            await _bus.Publish(message);
        }

        //Air Conditioner
        public async Task GetAirConditionerState()
        {
            var reply = await _airConditionerClient.GetStateAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var message = new AirConditionerStateChanged
            {
                Mode = reply.Mode,
                Temperature = reply.Temperature
            };
            await _bus.Publish(message);
        }
        public async Task TurnOnCooler()
        {
            var reply = await _airConditionerClient.TurnOnCoolerAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var message = new AirConditionerStateChanged
            {
                Mode = reply.Mode,
                Temperature = reply.Temperature
            };
            await _bus.Publish(message);
        }
        public async Task TurnOnHeater()
        {
            var reply = await _airConditionerClient.TurnOnHeaterAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var message = new AirConditionerStateChanged
            {
                Mode = reply.Mode,
                Temperature = reply.Temperature
            };
            await _bus.Publish(message);
        }
        public async Task IncreaseTemperature()
        {
            var reply = await _airConditionerClient.IncreaseTemperatureAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var message = new AirConditionerStateChanged
            {
                Mode = reply.Mode,
                Temperature = reply.Temperature
            };
            await _bus.Publish(message);
        }
        public async Task DecreaseTemperature()
        {
            var reply = await _airConditionerClient.DecreaseTemperatureAsync(new Google.Protobuf.WellKnownTypes.Empty());
            var message = new AirConditionerStateChanged
            {
                Mode = reply.Mode,
                Temperature = reply.Temperature
            };
            await _bus.Publish(message);
        }
    }
}