using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeControl.Api.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace HomeControl.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddControllers();

            //Register gRPC clients
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HomeControl.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeControl.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<LightHub>("/light");
                endpoints.MapControllers();
            });
        }
    }
}
