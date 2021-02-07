using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Mappings
{
    internal sealed class GenreMappingConfiguration : BaseMappingConfiguration<Genre>
    {
        public override void Map(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name");

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