using LibraryManagement.Applicaiton.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibraryManagement.Persistence.Tools.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ILibraryManagementDbContext, LibraryManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SQL"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    sqlOptions.EnableRetryOnFailure();
                }));

            var serviceProvider = services.BuildServiceProvider();
            IServiceScopeFactory scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();

            using var scope = scopeFactory.CreateScope();
            serviceProvider.GetRequiredService<ILibraryManagementDbContext>().Database.Migrate();
        }
    }
}
