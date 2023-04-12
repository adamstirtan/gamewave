using System.ComponentModel.DataAnnotations;

namespace GameWave.ObjectModel
{
    public class Genre : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}