using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBoss.ObjectModel
{
    [Table("Games")]
    public class Game : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Slug { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public virtual Company Developer { get; set; }

        public virtual Company Publisher { get; set; }

        public virtual ICollection<Release> Releases { get; set; }
    }
}