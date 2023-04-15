using System;
using System.ComponentModel.DataAnnotations;

namespace GameWave.Api.DTO
{
	public class CreateUserDTO
	{
		[Required]
		[StringLength(256)]
		public string UserName { get; set; }

		[Required]
		public string Password { get; set; }

		[StringLength(256)]
		public string Email { get; set; }
	}
}

