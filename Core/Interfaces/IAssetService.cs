using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetModel>> GetAssetsAsync();
    }
}
