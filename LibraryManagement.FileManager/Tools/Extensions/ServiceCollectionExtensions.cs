using LibraryManagement.FileManager.Interfaces;
using LibraryManagement.FileManager.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.FileManager.Tools.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFileManager(this IServiceCollection services)
        {
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IFileDeleteService, FileDeleteService>();
        }
    }
}
