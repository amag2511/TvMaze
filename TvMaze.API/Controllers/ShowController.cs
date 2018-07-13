using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMaze.API.DataAccess.Interfaces;
using TvMaze.API.DataAccess.Models;
using TvMaze.API.Models;
using TvMaze.API.Services.Interfaces;

namespace TvMaze.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShowController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IRepository<Show> _repository;

		public ShowController(IMapper mapper, IRepository<Show> repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		// GET api/show/5/5
		[HttpGet("{page}/{count}")]
		public async Task<ActionResult<List<ShowModel>>> Get(int? page, int? count)
		{
			var takePage = page ?? 1;
			var takeCount = count ?? 10;

			var showList = (await _repository.GetListAsync(
					(takePage - 1) * takeCount,
					takeCount,
					query => { return query.Include(b => b.ShowToCasts).ThenInclude(x => x.Cast); }))
				.Select(_mapper.Map)
				.ToList();

			return showList;

		}
	}
}
