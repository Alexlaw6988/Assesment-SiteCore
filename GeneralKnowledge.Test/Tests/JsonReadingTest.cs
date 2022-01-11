using System;
using System.Linq;
using System.Text;
using Core.Models;
using GeneralKnowledge.Test.App.Tests;
using Newtonsoft.Json;

namespace GeneralKnowledge.Test.Tests
{
    /// <summary>
    /// Basic data retrieval from JSON test
    /// </summary>
    public class JsonReadingTest : ITest
    {
        public string Name => "JSON Reading Test";

        public void Run()
        {
            var jsonData = Resources.SamplePoints;

            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z

            PrintOverview(jsonData);
        }

        private static void PrintOverview(byte[] json)
        {
            try
            {
                var jsonStr = Encoding.UTF8.GetString(json);
                var data = JsonConvert.DeserializeObject<SampleModel>(jsonStr);

                var samples = data.Samples.SelectMany(a => a)
                    .GroupBy(a => a.Key)
                    .Where(a => a.All(b=>double.TryParse(b.Value, out _)))
                    .Select(a=> new { Parameter = a.Key, Values = a.Select(b=>Convert.ToDouble(b.Value))});
                
                //var samples = new Dictionary<string, List<double>>();

                //foreach (var sample in data.Sample
                //{
                //    foreach (var (key, value) in sample)
                //    {
                //        if (!double.TryParse(value, out var doubleResult))
                //        {
                //            continue;
                //        }
                //        if (samples.ContainsKey(key))
                //        {
                //            samples[key].Add((doubleResult));
                //        }
                //        else
                //        {
                //            samples.Add(key,new List<double>{ doubleResult });
                //        }
                //    }
                //}
                Console.WriteLine(@"parameter   LOW AVG MAX");

                foreach (var obj in samples)
                {
                    Console.WriteLine($@"{obj.Parameter}   {obj.Values.Min()} {obj.Values.Average()} {obj.Values.Max()}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
