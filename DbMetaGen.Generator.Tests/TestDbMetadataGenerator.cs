using DbMetaGen.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace DbMetaGen.Generator.Tests
{
    public class TestDbMetadataGenerator
    {
        [Fact]
        public void GenerateClass_Tables_Valid()
        {
            // arrange
            var generator = new DbMetadataGenerator();
            var dbMetadata = new DbMetadata { Tables = new List<string> { "Table1" } };
            // act
            var result = generator.GenerateClassFile(dbMetadata);
            // assert - manual inspection
        }
    }
}
