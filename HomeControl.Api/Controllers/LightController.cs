using Microsoft.AspNetCore.Mvc;

namespace HomeControl.Api.Controllers
{
    public class LightController : ControllerBase
    {
        private readonly Light.LightClient _client;

        public LightController(Light.LightClient client)
        {
            _client = client;
        }
    }
}