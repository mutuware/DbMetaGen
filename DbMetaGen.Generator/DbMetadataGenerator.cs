using DbMetaGen.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DbMetaGen.Generator
{
    [Generator]
    public class DbMetadataGenerator : ISourceGenerator
    {

        public void Execute(SourceGeneratorContext context)
        {
            // TODO: Get metadata from tool output
            IEnumerable<AdditionalText> files = context.AdditionalFiles.Where(at => at.Path.EndsWith("DbMetadata.json"));

            AdditionalText dbMetadata = files.First();
            var dbMetadataText = dbMetadata.GetText().ToString();

            //var tables = dbMetadataText.Split(',').ToList();

            //var metadata = JsonSerializer.Deserialize<DbMetadata>(dbMetadataText); 
            // // json causes crashes - http://dontcodetired.com/blog/post/Using-C-Source-Generators-with-Microsoft-Feature-Management-Feature-Flags
            var metadata = JsonConvert.DeserializeObject<DbMetadata>(dbMetadataText);

            //var metadata = new DbMetadata
            //{
            //    Tables = tables
            //};


            var code = GenerateClassFile(metadata);

            context.AddSource($"Db", SourceText.From(code, Encoding.UTF8));
        }

        public string GenerateClassFile(DbMetadata metadata)
        {
            var sb = new StringBuilder();
            sb.AppendLine("namespace DbMetaGen");
            sb.AppendLine("{");
            sb.AppendLine("public static class Db");
            sb.AppendLine("{");
            foreach (var table in metadata.Tables)
            {
                sb.AppendLine($"public const string {table}= \"{table}\";");
            }
            sb.AppendLine("}");
            sb.AppendLine("}");

            var result = sb.ToString();
            return result;
        }

        public void Initialize(InitializationContext context)
        {
            //Debugger.Launch();
        }
    }
}
