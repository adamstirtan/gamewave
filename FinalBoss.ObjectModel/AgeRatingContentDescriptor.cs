using System.ComponentModel.DataAnnotations;

namespace FinalBoss.ObjectModel
{
    public class AgeRatingContentDescriptor : BaseEntity
    {
        [Required]
        public RatingSystem RatingSystemId { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}