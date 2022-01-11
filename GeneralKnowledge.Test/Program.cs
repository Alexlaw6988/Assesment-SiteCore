using System;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using GeneralKnowledge.Test.App.Tests;
using GeneralKnowledge.Test.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace GeneralKnowledge.Test
{
    internal class Program
    {
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ICsvService<AssetModel>, CsvService<AssetModel>>()
                .AddScoped<IJsonService, JsonService>()
                .AddScoped<IImageService, ImageService>()
                .BuildServiceProvider();
            // String manipulations
            var t1 = new StringTests();
            t1.Run();

            // Data retrieval from a JSON file
            var t2 = new JsonReadingTest();
            t2.Run();

            // Image manipulations
            var t3 = new RescaleImageTest();
            t3.Run();

            // Processing a CSV file
            var t4 = new CsvProcessingTest(serviceProvider);
            t4.Run();

            Console.WriteLine(@"Test execution ended.");
            Console.ReadKey();
        }
    }
}
