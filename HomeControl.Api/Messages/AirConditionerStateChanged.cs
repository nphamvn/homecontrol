namespace HomeControl.Api.Messages
{
    public class AirConditionerStateChanged
    {
        public string Mode { get; set; }
        public int Temperature { get; set; }
    }
}