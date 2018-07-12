using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TvMaze.API.Models;

namespace TvMaze.API.Services
{
	public class WebClient : IWebClient
	{
		private readonly HttpClient _client;

		public WebClient()
		{
			_client = new HttpClient();
		}

		public async Task<ResponseData<T>> GetApiDataAsync<T>(Uri path)
		{
			var responseData = new ResponseData<T>();

			try
			{
				var response = await _client.GetAsync(path);

				responseData.StatusCode = response.StatusCode;

				response.EnsureSuccessStatusCode();

				var responseBody = await response.Content.ReadAsStringAsync();
				
				responseData.Result = JsonConvert.DeserializeObject<T>(responseBody);
			}
			catch (HttpRequestException)
			{
				return responseData;
			}

			responseData.IsCompleted = true;
			return responseData;
		}

		public void Dispose()
		{
			_client?.Dispose();
		}
	}
}
