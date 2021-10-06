namespace HomeControl.Api.Messages
{
    public class EnvironmentSensorDataChanged
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}