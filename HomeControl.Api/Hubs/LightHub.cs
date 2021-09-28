using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HomeControl.Api.Hubs
{
    public class LightHub : Hub
    {
        public LightHub()
        {

        }
        public async Task TurnOnLight()
        {
            await Clients.All.SendAsync("LightStateChanged", "ON");
        }
    }
}