using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace FacturationWebSite
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			services.AddDbContext<MvcAppContext>(options => options.UseSqlite("Data Source=invoice.db"));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			var defaultDateCulture = "fr-FR";
			var ci = new CultureInfo(defaultDateCulture);
			ci.NumberFormat.NumberDecimalSeparator = ".";
			ci.NumberFormat.CurrencyDecimalSeparator = ".";

			// Configure the Localization middleware
			app.UseRequestLocalization(new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture(ci),
				SupportedCultures = new List<CultureInfo>
				{
					ci,
				},
				SupportedUICultures = new List<CultureInfo>
				{
					ci,
				}
			});

			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
