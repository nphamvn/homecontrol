using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HomeControl.Api.Hubs
{
    public class LightHub : Hub
    {
        private readonly Light.LightClient _client;

        public LightHub(Light.LightClient client)
        {
            _client = client;
        }
        public async Task TurnOnLight()
        {
            var reply = await _client.TurnOnLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("LightStateChanged", "ON");
        }
        public async Task TurnOffLight()
        {
            var reply = await _client.TurnOffLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("LightStateChanged", "ON");
        }
        public async Task BrightenLight()
        {
            var reply = await _client.BrightenLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("LightStateChanged", "ON");
        }
        public async Task DimLight()
        {
            var reply = await _client.DimLightAsync(new Google.Protobuf.WellKnownTypes.Empty());
            await Clients.All.SendAsync("LightStateChanged", "ON");
        }
    }
}