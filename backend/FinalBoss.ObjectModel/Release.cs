using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinalBoss.ObjectModel
{
    [Table("Releases")]
    public class Release : BaseEntity
    {
        [Required]
        public DateTimeOffset ReleaseDate { get; set; }

        [ForeignKey("Platform")]
        public long PlatformId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Platform Platform { get; set; }
    }
}