using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetModel>> GetAssetsAsync();
        Task CreateAssetAsync(AssetModel assetModel);
        Task UpdateAssetAsync(AssetModel assetModel);
        Task DeleteAssetAsync(int id);
    }
}
