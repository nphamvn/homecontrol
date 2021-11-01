using Microsoft.AspNetCore.Identity;

namespace HomeControl.Api.Models
{
    public class FamilyMember : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
    }
}