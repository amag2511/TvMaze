using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TvMaze.API.DataAccess;
using TvMaze.API.DataAccess.Interfaces;
using TvMaze.API.DataAccess.Models;
using TvMaze.API.Services;
using TvMaze.API.Services.Interfaces;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TvMaze.API
{
	public class Startup
	{
		private const string DEFAULT_CONNECTION = "DefaultConnection";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IWebClient, WebClient>();
			services.AddTransient<IMapper, Mapper>();
			services.AddTransient<IRepository<Show>, SqlRepository<Show>>();
			services.AddTransient<IRepository<Cast>, SqlRepository<Cast>>();
			services.AddTransient<IRepository<ShowToCast>, SqlRepository<ShowToCast>>();

			var connection = Configuration.GetConnectionString(DEFAULT_CONNECTION);

			services.AddDbContext<ShowContext>(options =>
				options.UseSqlServer(connection));

			services.AddSingleton<IHostedService, FetchDataBackgroundService>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}
	}
}
