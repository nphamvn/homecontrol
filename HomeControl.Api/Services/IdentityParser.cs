using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using HomeControl.Api.Models;

namespace HomeControl.Api.Services
{
    //https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Web/WebMVC/Services/IdentityParser.cs
    public class IdentityParser : IIdentityParser<FamilyMember>
    {
        public FamilyMember Parse(IPrincipal principal)
        {
            if (principal is ClaimsPrincipal claims)
            {
                return new FamilyMember
                {
                    Email = claims.Claims.FirstOrDefault(x => x.Type == "email")?.Value ?? ""
                };
            }
            else
            {
                throw new ArgumentException(message: "The principal must be a ClaimsPrincipal", paramName: nameof(principal));
            }
        }
    }
}