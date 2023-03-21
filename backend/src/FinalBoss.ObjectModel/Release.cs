using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBoss.ObjectModel
{
    [Table("Releases")]
    public class Release : BaseEntity
    {
        [Required]
        public DateTimeOffset ReleaseDate { get; set; }

        [Required]
        public virtual Platform Platform { get; set; }
    }
}