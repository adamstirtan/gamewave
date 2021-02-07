using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Mappings
{
    internal sealed class GameMappingConfiguration : BaseMappingConfiguration<Game>
    {
        public override void Map(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Created)
                .IsRequired()
                .HasColumnType(ColumnTypeDateTimeOffset)
                .HasColumnName("Created");

            builder.Property(x => x.LastModified)
                .IsRequired()
                .HasColumnType(ColumnTypeDateTimeOffset)
                .HasColumnName("LastModified");
        }
    }
}