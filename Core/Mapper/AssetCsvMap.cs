using Core.Models;
using CsvHelper.Configuration;

namespace Core.Mapper
{
    public sealed class AssetCsvMap : ClassMap<AssetModel>
    {
        public AssetCsvMap()
        {
            Map(m => m.AssetId).Name("asset id");
            Map(m => m.FileName).Name("file_name");
            Map(m => m.MimeType).Name("mime_type");
            Map(m => m.CreatedBy).Name("created_by");
            Map(m => m.Email).Name("email");
            Map(m => m.Country).Name("country");
            Map(m => m.Description).Name("description");
        }
    }
}
