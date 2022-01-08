using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBoss.ObjectModel
{
    [Table("Releases")]
    public class Release : BaseEntity
    {
        public DateTimeOffset ReleaseDate { get; set; }

        public virtual Platform Platform { get; set; }
    }
}