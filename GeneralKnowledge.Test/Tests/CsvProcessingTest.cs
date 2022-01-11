using System;
using System.IO;
using System.Linq;
using Core.Entities;
using Core.Interfaces;
using Core.Mapper;
using Core.Models;
using Core.Services;
using GeneralKnowledge.Test.App;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest

    {
        private readonly IServiceProvider _service;
        private readonly ICsvService<AssetModel> _csvService;
        public CsvProcessingTest(IServiceProvider service)
        {
            _service = service;
            _csvService = service.GetService<ICsvService<AssetModel>>();
        }
        public void Run()
        {
            // TODO
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted
            var csvFileContent = @"Resources\AssetImport.csv";
            
            var assets = _csvService.ReadCsvFile(csvFileContent, new AssetCsvMap());
        }
    }

}
