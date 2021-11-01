using HomeControl.Api.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HomeControl.Api.DenpendencyInjections
{
    public static class DbConfiguration
    {
        public static void AddSqliteDbContext(this IServiceCollection service)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite("Data Source=HomeControl.db");
            });
        }
    }
}