using System.ComponentModel.DataAnnotations;

namespace FinalBoss.Models
{
    public class AddGameForm
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public long DeveloperId { get; set; }

        [Required]
        public long PublisherId { get; set; }
    }
}
