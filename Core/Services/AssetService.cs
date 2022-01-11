using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class AssetService : IAssetService
    {
        private readonly IRepository<Asset> _assetRepository;
        private readonly IMapper _mapper;

        public AssetService(IRepository<Asset> customerRepository, IMapper mapper)
        {
            _assetRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssetModel>> GetAssetsAsync()
        {
            var assets = await _assetRepository.GetAllAsync();
            return assets.Select(a => _mapper.Map<AssetModel>(a));
        }

    }
   
}
