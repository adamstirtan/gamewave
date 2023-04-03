using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBoss.ObjectModel
{
	[Table("GameModes")]
	public class GameMode
	{
		[Required]
		public string Name { get; set; }
	}
}

