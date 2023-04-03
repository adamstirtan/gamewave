using System.ComponentModel.DataAnnotations;

namespace FinalBoss.ObjectModel
{
    public class GameEngine : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Slug { get; set; }

        [Required]
        public string Description { get; set; }

        [StringLength(255)]
        public string LogoUrl { get; set; }
    }
}