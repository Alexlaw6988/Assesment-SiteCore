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
            var assets = (await _assetRepository.GetAllAsync()).OrderByDescending(x=>x.Id);
            return assets.Select(a => _mapper.Map<AssetModel>(a));
        }

        public async Task CreateAssetAsync(AssetModel assetModel)
        {
            await _assetRepository.AddAsync(_mapper.Map<Asset>(assetModel));
        }

        public async Task UpdateAssetAsync(AssetModel assetModel)
        {
            await _assetRepository.UpdateAsync(_mapper.Map<Asset>(assetModel));
        }

        public async Task DeleteAssetAsync(int id)
        {
            await _assetRepository.DeleteAsync(_mapper.Map<Asset>(await _assetRepository.GetByIdAsync(id)));
        }

    }

}
