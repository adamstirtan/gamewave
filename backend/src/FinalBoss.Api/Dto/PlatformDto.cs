using System.ComponentModel.DataAnnotations;

namespace FinalBoss.Api.Dto
{
	public class PlatformDto : BaseDto
	{
		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		[StringLength(255)]
		public string ImageUrl { get; set; }

		[Required]
		public int Generation { get; set; }
	}
}

