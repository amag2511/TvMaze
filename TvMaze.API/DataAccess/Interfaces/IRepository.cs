using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvMaze.API.DataAccess.Interfaces
{
	public interface IRepository<T> : IDisposable
		where T : class
	{
		Task<List<T>> GetListAsync(int skipCount, int takeCount, Func<IQueryable<T>, IQueryable<T>> includes);
		Task<T> GetAsync(int id);
		Task CreateAsync(T item);
		void Update(T item);
		void UpdateRange(List<T> item);
		void Delete(T item);
		Task SaveAsync();
	}
}
