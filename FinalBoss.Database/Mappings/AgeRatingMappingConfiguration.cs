using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Mappings
{
    internal sealed class AgeRatingMappingConfiguration : BaseMappingConfiguration<AgeRating>
    {
        public override void Map(EntityTypeBuilder<AgeRating> builder)
        {
            builder.ToTable("AgeRatings");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RatingSystem)
                .IsRequired()
                .HasColumnType(ColumnTypeInteger)
                .HasColumnName("RatingSystem");

            builder.Property(x => x.Rating)
                .IsRequired()
                .HasColumnType(ColumnTypeInteger)
                .HasColumnName("Rating");

            builder.Property(x => x.Summary)
                .IsRequired()
                .HasMaxLength(1024)
                .HasColumnName("Summary");

            builder.HasMany(x => x.ContentDescriptors)
                .WithOne(x => x.AgeRating)
                .HasForeignKey(x => x.AgeRatingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}