using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProjectX.Application.Tools.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
        }
    }
}
