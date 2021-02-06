using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FinalBoss.ObjectModel;

namespace FinalBoss.Database.Mappings
{
    internal sealed class AgeRatingContentDescriptorMappingConfiguration : BaseMappingConfiguration<AgeRatingContentDescriptor>
    {
        public override void Map(EntityTypeBuilder<AgeRatingContentDescriptor> builder)
        {
            builder.ToTable("AgeRatingContentDescriptors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RatingSystemId)
                .IsRequired()
                .HasColumnType(ColumnTypeInteger)
                .HasColumnName("RatingSystemId");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Description");
        }
    }
}