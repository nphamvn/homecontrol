using System;

namespace HomeControl.Api.Models
{
    public class AuthToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}