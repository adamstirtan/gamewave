using System;
using System.ComponentModel.DataAnnotations;

namespace FinalBoss.Api.Dto
{
	public class PlatformDto : BaseDto
	{
        public long? Id { get; set; }

        public DateTimeOffset? Created { get; set; }

        public DateTimeOffset? LastModified { get; set; }

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
        public int Category { get; set; }

        [Required]
        public int Generation { get; set; }
    }
}

