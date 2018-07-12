using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvMaze.API.DataAccess.Models
{
	public class Show
	{
		public int Id { get; set; }

		public int ApiId { get; set; }

		public string Name { get; set; }

		public List<ShowToCast> ShowToCasts { get; set; } = new List<ShowToCast>();
	}
}
