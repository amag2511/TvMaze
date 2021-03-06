﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TvMaze.API.DataAccess.Models
{
	public class Cast
	{
		public int Id { get; set; }

		public int ApiId { get; set; }

		public string Name { get; set; }

		public DateTime? Birthday { get; set; }

		public List<ShowToCast> ShowToCasts { get; set; } = new List<ShowToCast>();
	}
}
