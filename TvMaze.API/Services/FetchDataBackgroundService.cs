using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TvMaze.API.DataAccess;
using TvMaze.API.DataAccess.Models;
using TvMaze.API.DataModels;
using TvMaze.API.Services.Interfaces;

namespace TvMaze.API.Services
{
	public class FetchDataBackgroundService : BackgroundService
	{
		private const string MAX_SHOW_ITEMS_KEY = "MaxShowItemsKey";
		private const string API_SHOW_PATH_PATTERN_KEY = "ApiShowPathPattern";

		private readonly IWebClient _webClient;
		private readonly IServiceProvider _serviceProvider;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		public FetchDataBackgroundService(IWebClient webClient, IMapper mapper, IConfiguration configuration, IServiceProvider serviceProvider)
		{
			_configuration = configuration;
			_webClient = webClient;
			_mapper = mapper;
			_serviceProvider = serviceProvider;
		}

		//Add logger
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var count = 1;

			int.TryParse(_configuration[MAX_SHOW_ITEMS_KEY], out var maxShowItems);

			using (var repository = _serviceProvider.GetService<SqlRepository<Show>>())
			{
				while (!stoppingToken.IsCancellationRequested)
				{
					var responseData =
						await _webClient.GetApiDataAsync<ShowDataModel>(
							new Uri(string.Format(_configuration[API_SHOW_PATH_PATTERN_KEY], count++)));

					if (responseData.StatusCode == HttpStatusCode.OK)
					{
						repository.Update(_mapper.Map(responseData.Result));
						await repository.SaveAsync();
					}

					else if (count >= maxShowItems)
					{
						return;
					}
				}
			}
		}

		public override void Dispose()
		{
			_webClient.Dispose();
			base.Dispose();
		}
	}
}
