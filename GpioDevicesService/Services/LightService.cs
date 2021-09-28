using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GpioDevicesService.Services
{
    public class LightService : Light.LightBase
    {
        public LightService()
        {

        }
        public override Task<LightReply> GetStatus(Empty request, ServerCallContext context)
        {
            return base.GetStatus(request, context);
        }

        public override Task<LightReply> TurnOnLight(Empty request, ServerCallContext context)
        {
            //Save change
            return base.TurnOnLight(request, context);
        }

        public override Task<LightReply> TurnOffLight(Empty request, ServerCallContext context)
        {
            //Save change
            return base.TurnOffLight(request, context);
        }

        public override Task<LightReply> BrightenLight(Empty request, ServerCallContext context)
        {
            //Save change
            return base.BrightenLight(request, context);
        }

        public override Task<LightReply> DimLight(Empty request, ServerCallContext context)
        {
            //Save change
            return base.DimLight(request, context);
        }
    }
}