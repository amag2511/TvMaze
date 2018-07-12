using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TvMaze.API.DataAccess;
using TvMaze.API.DataAccess.Interfaces;
using TvMaze.API.DataAccess.Models;
using TvMaze.API.DataModels;
using TvMaze.API.Services.Interfaces;

namespace TvMaze.API.Services
{
	public class FetchDataBackgroundService : BackgroundService
	{
		private const int MAX_SHOW_ITEMS = 37690;
		private const string API_SHOW_PATH_PATTERN = "http://api.tvmaze.com/shows/{0}?embed=cast";

		private readonly IWebClient _webClient;

		public FetchDataBackgroundService(IWebClient webClient)
		{
			_webClient = webClient;
		}

		//Add logger
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var count = 1;
			while (!stoppingToken.IsCancellationRequested)
			{
				var responseData = await _webClient.GetApiDataAsync<ShowDataModel>(new Uri(string.Format(API_SHOW_PATH_PATTERN, count++)));
				if (responseData.StatusCode == HttpStatusCode.OK)
				{
					// Use message queue here after deviding into microservices
				}
				else if (count >= MAX_SHOW_ITEMS)
				{
					return;
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
