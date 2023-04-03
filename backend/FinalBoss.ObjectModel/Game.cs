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

        [ForeignKey("Developer")]
        public long DeveloperId { get; set; }

        public Company? Developer { get; set; }

        [ForeignKey("Publisher")]
        public long PublisherId { get; set; }

        public Company? Publisher { get; set; }

        public ICollection<Release> Releases { get; set; }
    }
}