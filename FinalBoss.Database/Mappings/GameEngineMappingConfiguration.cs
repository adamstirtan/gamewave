using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Mappings
{
    internal class GameEngineMappingConfiguration : BaseMappingConfiguration<GameEngine>
    {
        public override void Map(EntityTypeBuilder<GameEngine> builder)
        {
            builder.ToTable("GameEngines");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description");

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Slug");

            builder.Property(x => x.LogoUrl)
                .HasMaxLength(255)
                .HasColumnName("LogoUrl");

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