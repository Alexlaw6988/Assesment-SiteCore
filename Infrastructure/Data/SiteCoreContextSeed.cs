using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Mapper;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public class SiteCoreContextSeed
    {
        public static async Task SeedAssetsAsync(IServiceProvider services)
        {
            var context = services.GetService<SiteCoreContext>();
            var assets = context.Set<Asset>();
            var any = await assets.AnyAsync();
            var mapper = services.GetService<IMapper>();

            if (!any)
            {
                const string csvFile = "Resources/AssetImport.csv";
                var csvService = services.GetService<ICsvService<AssetModel>>();
                var assetModels = csvService.ReadCsvFile(csvFile, new AssetCsvMap()).Select(x => mapper.Map<Asset>(x));
                await assets.AddRangeAsync(assetModels);
            }

            await context.SaveChangesAsync();
        }
    }
}
