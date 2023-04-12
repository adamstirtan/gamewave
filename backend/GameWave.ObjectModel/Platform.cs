using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameWave.ObjectModel
{
    [Table("Platforms")]
    public class Platform : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Slug { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        [Required]
        [Range(1, 6)]
        public PlatformCategory Category { get; set; }

        [Required]
        public int Generation { get; set; }
    }
}