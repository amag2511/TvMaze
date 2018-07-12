using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMaze.API.DataAccess.Interfaces;
using TvMaze.API.DataAccess.Models;

namespace TvMaze.API.DataAccess
{
	public class SqlRepository<T> : IRepository<T>
		where T : class
	{
		private bool _disposed = false;
		private readonly ShowContext _dbContext;

		public SqlRepository(ShowContext context)
		{
			_dbContext = context;
		}
		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public async Task<List<T>> GetListAsync(int skipCount, int takeCount)
		{
			return await _dbContext.Set<T>()?
				.Skip(skipCount)
				.Take(takeCount)
				.ToListAsync();
		}

		public async Task<T> GetAsync(int id)
		{
			return await _dbContext.Set<T>().FindAsync(id);
		}

		public async Task CreateAsync(T item)
		{
			await _dbContext.Set<T>().AddAsync(item);
		}

		public void Update(T item)
		{
			_dbContext.Set<T>().Update(item);
		}

		public void UpdateRange(List<T> item)
		{
			_dbContext.Set<T>().UpdateRange(item);
		}

		public void Delete(T item)
		{
			_dbContext.Set<T>().Remove(item);
		}

		public async Task SaveAsync()
		{
			await _dbContext.SaveChangesAsync();

		}
	}
}
