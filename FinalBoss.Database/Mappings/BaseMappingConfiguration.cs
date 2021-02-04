using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Mappings
{
    internal abstract class BaseMappingConfiguration<T> : IEntityMappingConfiguration<T> where T : BaseEntity
    {
        protected const string ColumnTypeId = "bigint";
        protected const string ColumnTypeInteger = "int";
        protected const string ColumnTypeBigInteger = "bigint";
        protected const string ColumnTypeBoolean = "bit";
        protected const string ColumnTypeDateTime = "datetime";
        protected const string ColumnTypeDateTimeOffset = "datetimeoffset";
        protected const string ColumnTypeTime = "time";

        protected const string ColumnTypeMoney = "money";
        protected const string ColumnTypeDecimal = "decimal";
        protected const string ColumnTypeGeography = "geography";
        protected const string ColumnTypeBinary = "binary";
        protected const string ColumnTypeVariableBinary = "varbinary";

        public abstract void Map(EntityTypeBuilder<T> builder);

        public void Map(ModelBuilder builder)
        {
            Map(builder.Entity<T>());
        }
    }
}