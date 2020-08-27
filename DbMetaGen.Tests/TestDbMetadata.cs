using Xunit;

namespace DbMetaGen.Tests
{
    public class TestDbMetadata
    {
        [Fact]
        public void Get_Tables_HasData()
        {
            // arrange
            var connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Foodie; Integrated Security=true";
            IDbMetadata dbMetadata = new SqlDbMetadata(connectionString);
            // act
            var result = dbMetadata.Get();
            // assert
            Assert.True(result.Tables.Count > 0);
        }
    }
}
