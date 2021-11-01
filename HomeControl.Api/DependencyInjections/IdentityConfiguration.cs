using HomeControl.Api.DbContext;
using HomeControl.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HomeControl.Api.DenpendencyInjections
{
    public static class IdentityConfiguration
    {
        public static void ConfigureIdentity(this IServiceCollection service)
        {
            service.AddIdentity<FamilyMember, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}