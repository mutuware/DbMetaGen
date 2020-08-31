using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DbMetaGen.Provider
{
    class Program
    {
        private static string fileName = "DbMetadata.json";

        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                       .SetBasePath(Directory.GetCurrentDirectory())
                                       .AddJsonFile("appsettings.json", false)
                                       .Build();

            var connectionKey = args.Length > 0 ? args[0] : "Default";
            Console.WriteLine($"Using appSettings ConnectionString Key:{connectionKey}");
            var connectionString = configuration.GetConnectionString(connectionKey);

            Console.WriteLine("Retreiving metadata");
            IDbMetadataProvider dbMetadataProvider = new SqlDbMetadataProvider(connectionString);
            var metadata = dbMetadataProvider.Get();
            Console.WriteLine("Writing DbMetadata.json");
            File.WriteAllText(fileName, JsonConvert.SerializeObject(metadata)); // writes to currect directory
        }
    }
}
