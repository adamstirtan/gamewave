using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Mappings
{
    internal interface IEntityMappingConfiguration
    {
        void Map(ModelBuilder builder);
    }

    internal interface IEntityMappingConfiguration<T> : IEntityMappingConfiguration where T : BaseEntity
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}