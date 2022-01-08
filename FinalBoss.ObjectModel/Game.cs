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
        [StringLength(255)]
        public string Slug { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual Company Developer { get; set; }

        public virtual Company Publisher { get; set; }

        public virtual ICollection<Release> Releases { get; set; }
    }
}