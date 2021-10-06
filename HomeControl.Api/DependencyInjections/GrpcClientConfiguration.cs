using System;
using HomeControl.Api.EventHandlers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace HomeControl.Api.DenpendencyInjections
{
    public static class GrpcClientConfiguration
    {
        public static void AddGrpcClients(this IServiceCollection services)
        {
            services.AddGrpcClient<Light.LightClient>(o =>
            {
                o.Address = new Uri("https://localhost:5001");
            });
            services.AddGrpcClient<AirConditioner.AirConditionerClient>(o =>
            {
                o.Address = new Uri("https://localhost:5001");
            });
            services.AddGrpcClient<EnvironmentSensor.EnvironmentSensorClient>(o =>
            {
                o.Address = new Uri("https://localhost:5001");
            });
        }

        public static void AddMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<AirConditionerStateChangedEventHandler>();
                x.AddConsumer<EnvironmentSensorDataChangedEventHandler>();
                x.AddConsumer<LightStateChangedEventHandler>();

                x.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });

            });
            
            services.AddMassTransitHostedService(true);
        }
    }
}