using Core.Interfaces;
using Core.Models;
using Core.Services;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace WebExperience.Test
{
    public static class StartupExtentions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<ICsvService<AssetModel>, CsvService<AssetModel>>();
            services.AddScoped<IJsonService, JsonService>();
            services.AddScoped<IImageService, ImageService>();
        }
    }
}
