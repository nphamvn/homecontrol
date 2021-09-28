using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GpioDevicesService.Services
{
    public class AirConditionerService : AirConditioner.AirConditionerBase
    {
        public AirConditionerService()
        {

        }
        public override Task<AirConditionerReply> TurnOnCooler(Empty request, ServerCallContext context)
        {
            return base.TurnOnCooler(request, context);
        }
        public override Task<AirConditionerReply> TurnOnHeater(Empty request, ServerCallContext context)
        {
            return base.TurnOnHeater(request, context);
        }
        public override Task<AirConditionerReply> IncreaseTemperature(Empty request, ServerCallContext context)
        {
            return base.IncreaseTemperature(request, context);
        }
        public override Task<AirConditionerReply> DecreaseTemperature(Empty request, ServerCallContext context)
        {
            return base.DecreaseTemperature(request, context);
        }
    }
}