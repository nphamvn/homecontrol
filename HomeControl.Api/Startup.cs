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
using HomeControl.Api.EventHandlers;
using HomeControl.Api.DenpendencyInjections;
using HomeControl.Api.Workers;
using HomeControl.Api.Tests;
using HomeControl.Api.Services;

namespace HomeControl.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            TestService.Instance.Initialize();
            services.AddSingleton<ITestService>(TestService.Instance);

            //
            services.AddSqliteDbContext();

            //
            services.ConfigureIdentity();

            //
            services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Section));
            services.ConfigAuthentication();

            services.AddSingleton<TokenService>();

            //
            services.AddSignalR();

            //Add Controllers
            services.AddControllers();

            //Add Background Services
            services.AddHostedService<EnvironmentSensorWorker>();

            //Add CORS
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200", "http://localhost:4201");

                // builder.WithOrigins("https://nphamvn.github.io/", "https://homecontrol-fe.azurewebsites.net", "http://localhost:4200")
                // .AllowAnyHeader()
                // .WithMethods("GET", "POST")
                // .AllowCredentials();
            }));

            //Register gRPC clients
            services.AddGrpcClients();

            //Add MassTransit
            services.AddMassTransit();

            //Add Swagger
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            //app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<DevicesControllerHub>("/devicescontrol");
                endpoints.MapHub<NotificationHub>("/notification");
                endpoints.MapControllers();
            });
        }
    }
}
