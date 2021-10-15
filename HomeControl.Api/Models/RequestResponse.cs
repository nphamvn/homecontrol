namespace HomeControl.Api.Models
{
    public class RequestResponse<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}