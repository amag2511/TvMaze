using Microsoft.EntityFrameworkCore;
using TvMaze.API.DataAccess.Models;

namespace TvMaze.API.DataAccess
{
	public class ShowContext : DbContext
	{
		public DbSet<Show> Shows { get; set; }
		public DbSet<Cast> Casts { get; set; }

		public ShowContext(DbContextOptions<ShowContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ShowToCast>()
				.HasKey(t => new { t.ShowId, t.CastId });
		}
	}
}
