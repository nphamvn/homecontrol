using System.Threading.Tasks;
using HomeControl.Api.Hubs;
using HomeControl.Api.Messages;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace HomeControl.Api.EventHandlers
{
    public class AirConditionerStateChangedEventHandler : IConsumer<AirConditionerStateChanged>
    {
        private readonly IHubContext<DevicesControllerHub> _hubContext;

        public AirConditionerStateChangedEventHandler(IHubContext<DevicesControllerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<AirConditionerStateChanged> context)
        {
            await _hubContext.Clients.All.SendAsync(nameof(AirConditionerStateChanged), context.Message);
        }
    }
}