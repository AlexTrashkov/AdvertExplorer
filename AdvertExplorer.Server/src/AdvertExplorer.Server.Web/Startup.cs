using AdvertExplorer.Server.Domain.Services;
using AdvertExplorer.Server.Storage;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AdvertExplorer.Server.Web
{
	public sealed class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc();
			services.AddCors(o => o.AddPolicy("FullAccess", corsBuilder =>
			{
				corsBuilder
					.AllowAnyOrigin()
					.AllowAnyHeader();
			}));

			// Create the container builder.
			var builder = new ContainerBuilder();
			builder.RegisterModule<WebModule>();

			var container = builder.Build();

			//TODO need delete this block and setup communications between .NET Core DI and Autofac
			services.AddSingleton(container.Resolve<IResumeService>());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMvc();
			app.UseDefaultFiles();
			app.UseStaticFiles();
		}
	}
}