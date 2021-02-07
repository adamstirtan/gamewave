using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalBoss.ObjectModel
{
    public class Game : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<AgeRating> AgeRatings { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}