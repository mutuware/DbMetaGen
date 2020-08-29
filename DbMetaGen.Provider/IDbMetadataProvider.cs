using DbMetaGen.Models;

namespace DbMetaGen.Provider
{
    public interface IDbMetadataProvider
    {
        public DbMetadata Get();
    }
}
