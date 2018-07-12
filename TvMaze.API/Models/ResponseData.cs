using System.Net;

namespace TvMaze.API.Models
{
	public class ResponseData<T>
	{
		public T Result { get; set; }
		public bool IsCompleted { get; set; }
		public HttpStatusCode StatusCode { get; set; }
	}
}
