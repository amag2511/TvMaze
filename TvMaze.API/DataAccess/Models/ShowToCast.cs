using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvMaze.API.DataAccess.Models
{
	public class ShowToCast
	{
		[ForeignKey("Show")]
		public int ShowId { get; set; }
		public Show Show { get; set; }

		[ForeignKey("Cast")]
		public int CastId { get; set; }
		public Cast Cast { get; set; }
	}
}
