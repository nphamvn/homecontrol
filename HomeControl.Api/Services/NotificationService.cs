using System.Threading.Tasks;
using HomeControl.Api.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace HomeControl.Api.Services
{
    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> _context;

        public NotificationService(IHubContext<NotificationHub> context)
        {
            _context = context;
        }
        public async Task PushNotification(string message)
        {
            await _context.Clients.All.SendAsync("NewNotification", message);
        }
    }
}