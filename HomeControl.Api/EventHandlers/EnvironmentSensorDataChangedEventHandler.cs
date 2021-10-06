using System.Threading.Tasks;
using HomeControl.Api.Hubs;
using HomeControl.Api.Messages;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace HomeControl.Api.EventHandlers
{
    public class EnvironmentSensorDataChangedEventHandler : IConsumer<EnvironmentSensorDataChanged>
    {
        private readonly IHubContext<DevicesControllerHub> _hubContext;

        public EnvironmentSensorDataChangedEventHandler(IHubContext<DevicesControllerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<EnvironmentSensorDataChanged> context)
        {
            await _hubContext.Clients.All.SendAsync(nameof(EnvironmentSensorDataChanged), context.Message);
        }
    }
}