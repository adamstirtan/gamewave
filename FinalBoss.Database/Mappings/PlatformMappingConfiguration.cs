using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Mappings
{
    internal sealed class PlatformMappingConfiguration : BaseMappingConfiguration<Platform>
    {
        public override void Map(EntityTypeBuilder<Platform> builder)
        {
            builder.ToTable("Platforms");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description");

            builder.Property(x => x.Slug)
                .HasMaxLength(255)
                .HasColumnName("Slug");

            builder.Property(x => x.Category)
                .IsRequired()
                .HasColumnType(ColumnTypeInteger)
                .HasColumnName("Category");

            builder.Property(x => x.Generation)
                .IsRequired()
                .HasColumnType(ColumnTypeInteger)
                .HasColumnName("Generation");

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