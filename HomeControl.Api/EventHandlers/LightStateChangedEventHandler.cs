using System.Threading.Tasks;
using HomeControl.Api.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace HomeControl.Api.EventHandlers
{
    public class LightStateChangedEventHandler//: Hanlder (MessagePub, EventBus, Mediator, MassTransit)
    {
        private readonly IHubContext<DevicesControllerHub> _hubContext;

        public LightStateChangedEventHandler(IHubContext<DevicesControllerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task OnHandled(object data)
        {
            //Notify to other client
        }
    }
}