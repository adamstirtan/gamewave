using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalBoss.ObjectModel
{
    public class AgeRating : BaseEntity
    {
        [Required]
        public RatingSystem RatingSystem { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [Required]
        [StringLength(1024)]
        public string Summary { get; set; }

        public virtual ICollection<AgeRatingContentDescriptor> ContentDescriptors { get; set; }
    }
}