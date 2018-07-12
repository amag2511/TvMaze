using System;
using System.Threading.Tasks;
using TvMaze.API.Models;

namespace TvMaze.API.Services
{
	public interface IWebClient : IDisposable
	{
		Task<ResponseData<T>> GetApiDataAsync<T>(Uri path);
	}
}
