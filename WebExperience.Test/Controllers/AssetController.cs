using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace WebExperience.Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly IMemoryCache _memoryCache;

        public AssetsController(IAssetService assetService, IMemoryCache memoryCache)
        {
            _assetService = assetService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IEnumerable<AssetModel>> Get()
        {
            const string cacheKey = "assetList";
            if (_memoryCache.TryGetValue(cacheKey, out IEnumerable<AssetModel> assetList)) return assetList.ToList();
            //calling the server
            assetList = await _assetService.GetAssetsAsync();

            //setting up cache options
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20)
            };
            //setting cache entries
            var assetModels = assetList.ToList();

            _memoryCache.Set(cacheKey, assetModels, cacheExpiryOptions);

            return assetModels;
        }
    }
}
