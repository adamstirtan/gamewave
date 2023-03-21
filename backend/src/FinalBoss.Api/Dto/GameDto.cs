using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalBoss.Api.Dto
{
    public class GameDto : BaseDto
    {
        public long? Id { get; set; }

        public DateTimeOffset? Created { get; set; }

        public DateTimeOffset? LastModified { get; set; }

        [Required]
        public long DeveloperId { get; set; }

        [Required]
        public long PublisherId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Slug { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public ICollection<ReleaseDto> Releases { get; set; }
    }
}