using System.Threading.Tasks;
using HomeControl.Api.Hubs;
using HomeControl.Api.Messages;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace HomeControl.Api.EventHandlers
{
    public class LightStateChangedEventHandler : IConsumer<LightStateChanged>
    {
        private readonly IHubContext<DevicesControllerHub> _hubContext;

        public LightStateChangedEventHandler(IHubContext<DevicesControllerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<LightStateChanged> context)
        {
            await _hubContext.Clients.All.SendAsync(nameof(LightStateChanged), context.Message);
        }
    }
}