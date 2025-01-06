using CMAPI.DataModel;
using Microsoft.EntityFrameworkCore;

namespace CMAPI.Extentions
{
    public static class DbContextServices
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("StrConDatabase"));
            });

            return services;
        }
    }
}
