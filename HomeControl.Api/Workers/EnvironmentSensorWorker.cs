using System.Threading;
using System.Threading.Tasks;
using HomeControl.Api.Messages;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HomeControl.Api.Workers
{
    public class EnvironmentSensorWorker : BackgroundService
    {
        private readonly EnvironmentSensor.EnvironmentSensorClient _client;
        private readonly ILogger<EnvironmentSensorWorker> _logger;
        private readonly IBus _bus;

        public EnvironmentSensorWorker(EnvironmentSensor.EnvironmentSensorClient client,
                            ILogger<EnvironmentSensorWorker> logger,
                            IBus bus)
        {
            _client = client;
            _logger = logger;
            _bus = bus;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            EnvironmentSensorReply lastValue = null;
            try
            {
                while (true)
                {
                    //var newValue = await _client.GetSensorDataAsync(new Google.Protobuf.WellKnownTypes.Empty());
                    //_logger.LogInformation(nameof(EnvironmentSensorWorker) + " running");
                    var newValue = new EnvironmentSensorReply
                    {
                        Temperature = new System.Random().Next(20, 40),
                        Humindity = 80
                    };
                    if (lastValue != null)
                    {
                        if (true)
                        {
                            //pulish notification here
                            var message = new EnvironmentSensorDataChanged
                            {
                                Temperature = newValue.Temperature,
                                Humidity = newValue.Humindity
                            };

                            await _bus.Publish(message);
                        }
                    }
                    lastValue = newValue;

                    await Task.Delay(2000, stoppingToken);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}