using System.ComponentModel.DataAnnotations;

namespace FinalBoss.ObjectModel
{
    public class Game : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
