using System;
using System.ComponentModel.DataAnnotations;

namespace FinalBoss.Api.Dto
{
	public class ReleaseDto : BaseDto
	{
        public long? Id { get; set; }

        public DateTimeOffset? Created { get; set; }

        public DateTimeOffset? LastModified { get; set; }

        [Required]
        public DateTimeOffset ReleaseDate { get; set; }

        [Required]
        public long PlatformId { get; set; }
    }
}

