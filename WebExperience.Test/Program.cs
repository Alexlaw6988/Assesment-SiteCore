using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using GeneralKnowledge.Test.App.Tests;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace WebExperience.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    SiteCoreContextSeed.SeedAssetsAsync(services).Wait();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
