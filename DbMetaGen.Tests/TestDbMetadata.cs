using Xunit;
using DbMetaGen;
using DbMetaGen.Provider;

namespace DbMetaGen.Tests
{
    public class TestDbMetadata
    {
        const string testDbConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Master; Integrated Security=true";

        [Fact]
        public void Get_Tables_HasData()
        {
            // arrange
            IDbMetadataProvider dbMetadata = new SqlDbMetadataProvider(testDbConnectionString);
            // act
            var result = dbMetadata.Get();
            // assert
            Assert.True(result.Tables.Count > 0);
        }
    }
}
