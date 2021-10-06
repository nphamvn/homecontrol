namespace HomeControl.Api.Messages
{
    public class LightStateChanged
    {
        public string Mode { get; set; }
        public int Brightness { get; set; }
    }
}