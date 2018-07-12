using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TvMaze.API.DataAccess.Interfaces;
using TvMaze.API.DataAccess.Models;
using TvMaze.API.DataModels;
using TvMaze.API.Models;
using TvMaze.API.Services;
using TvMaze.API.Services.Interfaces;

namespace TvMaze.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IRepository<Show> _repository;

		public ValuesController(IWebClient webClient, IMapper mapper, IRepository<Show> repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<string> Get()
		{
			return "to get data input i.e. api/values/5/4";
		}

		// GET api/values/5
		[HttpGet("{page}/{count}")]
		public async Task<ActionResult<List<ShowModel>>> Get(int? page, int? count)
		{
			var takePage = page ?? 1;
			var takeCount = count ?? 10;

			var showList = (await _repository.GetListAsync())
				.Skip((takePage - 1) * takeCount)
				.Take(takeCount)
				.Select(_mapper.Map)
				.ToList();

			return showList;

		}
	}
}
