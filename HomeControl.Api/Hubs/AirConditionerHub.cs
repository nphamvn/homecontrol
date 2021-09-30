using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HomeControl.Api.Hubs
{
    public class AirConditionerHub : Hub
    {
        public AirConditionerHub()
        {

        }
        public async Task TurnOnCooler()
        {
            await Clients.All.SendAsync("LightStateChanged", "ON");
        }
    }
}