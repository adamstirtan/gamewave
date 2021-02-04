using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Mappings
{
    internal class GameEngineMappingConfiguration : BaseMappingConfiguration<GameEngine>
    {
        public override void Map(EntityTypeBuilder<GameEngine> builder)
        {
            builder.ToTable("Notes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LastModified)
                .IsRequired()
                .HasColumnType(ColumnTypeDateTimeOffset)
                .HasColumnName("LastModified");

            builder.Property(x => x.Created)
                .IsRequired()
                .HasColumnType(ColumnTypeDateTimeOffset)
                .HasColumnName("Created");
        }
    }
}