using System.Collections.Generic;
using CsvHelper.Configuration;

namespace Core.Interfaces
{
    public interface ICsvService<T>
    {
        IEnumerable<T> ReadCsvFile(string fileLocation, ClassMap<T> columnMap = null);
    }
}
