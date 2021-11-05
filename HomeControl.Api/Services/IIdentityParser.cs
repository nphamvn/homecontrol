using System.Security.Principal;

namespace HomeControl.Api.Services
{
    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}