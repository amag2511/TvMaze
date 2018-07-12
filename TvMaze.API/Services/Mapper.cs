using System;
using System.Linq;
using TvMaze.API.DataAccess.Models;
using TvMaze.API.DataModels;
using TvMaze.API.Models;
using TvMaze.API.Services.Interfaces;

namespace TvMaze.API.Services
{
	public class Mapper : IMapper
	{
		private const string DATETIME_FORMAT = "yyyy-MM-dd";

		public Show Map(ShowDataModel showItemDataModel)
		{
			if (showItemDataModel == null)
			{
				return null;
			}

			var show = new Show
			{
				ShowId = showItemDataModel.Id,
				Name = showItemDataModel.Name
			};

			return new Show
			{
				ShowId = showItemDataModel.Id,
				Name = showItemDataModel.Name,
				ShowToCasts = showItemDataModel.Embedded.Cast.Select(x => Map(show, Map(x))).ToList()
			};
		}

		public ShowModel Map(Show show)
		{
			if (show == null)
			{
				return null;
			}

			return new ShowModel
			{
				Id = show.ShowId,
				Name = show.Name,
				Cast = show.ShowToCasts.OrderBy(x => x.Cast.Birthday).Select(x => Map(x.Cast)).ToList()
			};
		}

		private Cast Map(CastDataModel castDataModel)
		{
			if (castDataModel?.Person == null)
			{
				return null;
			}

			var cast = new Cast
			{
				CastId = castDataModel.Person.Id,
				Name = castDataModel.Person.Name
			};

			if (castDataModel.Person.Birthday != null)
			{
				DateTime.TryParse(castDataModel.Person.Birthday, out var birthday);

				cast.Birthday = birthday;
			}

			return cast;
		}

		private ShowToCast Map(Show show, Cast cast)
		{
			if (cast == null && show == null)
			{
				return null;
			}

			return new ShowToCast
			{
				Show = show,
				Cast = cast
			};
		}

		private CastModel Map(Cast cast)
		{
			if (cast == null)
			{
				return null;
			}
			var castModel = new CastModel
			{
				Id = cast.CastId,
				Name = cast.Name,
				Birthday = cast.Birthday?.ToString(DATETIME_FORMAT)
			};

			return castModel;
		}
	}
}
