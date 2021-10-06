using System.Threading.Tasks;
using HomeControl.Api.Hubs;
using HomeControl.Api.Messages;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace HomeControl.Api.EventHandlers
{
    public class LightStateChangedEventHandler : IConsumer<LightStateChanged>
    {
        private readonly IHubContext<DevicesControllerHub> _hubContext;
        private readonly ILogger<LightStateChangedEventHandler> _logger;

        public LightStateChangedEventHandler(IHubContext<DevicesControllerHub> hubContext, ILogger<LightStateChangedEventHandler> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<LightStateChanged> context)
        {
            _logger.LogInformation(nameof(ConsumeContext<LightStateChanged>));
            await _hubContext.Clients.All.SendAsync(nameof(LightStateChanged), context.Message);
        }
    }
}