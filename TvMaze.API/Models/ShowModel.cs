using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvMaze.API.Models
{
	public class ShowModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<CastModel> Cast { get; set; }
	}
}
