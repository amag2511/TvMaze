using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMaze.API.DataAccess.Models;
using TvMaze.API.DataModels;
using TvMaze.API.Models;

namespace TvMaze.API.Services.Interfaces
{
	public interface IMapper
	{
		Show Map(ShowDataModel showItemDataModel);
		ShowModel Map(Show show);
	}
}
