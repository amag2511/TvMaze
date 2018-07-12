﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvMaze.API.DataAccess.Models
{
	public class Show
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ShowId { get; set; }

		public string Name { get; set; }

		public List<ShowToCast> ShowToCasts { get; set; } = new List<ShowToCast>();
	}
}
