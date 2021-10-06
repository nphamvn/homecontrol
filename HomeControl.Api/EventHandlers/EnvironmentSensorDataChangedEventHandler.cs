using System.Threading.Tasks;
using HomeControl.Api.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace HomeControl.Api.EventHandlers
{
    public class EnvironmentSensorDataChangedEventHandler//: Hanlder (MessagePub, EventBus, Mediator, MassTransit)
    {
        private readonly IHubContext<DevicesControllerHub> _hubContext;

        public EnvironmentSensorDataChangedEventHandler(IHubContext<DevicesControllerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task OnHandled(object data)
        {
        }
    }
}