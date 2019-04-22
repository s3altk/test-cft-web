using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Globalization;
using TestCft.Models;

namespace TestCft
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DbModel>(options => options.UseSqlServer(connectionString));

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo>()
                {
                    CultureInfo.CreateSpecificCulture("de-DE")
                };

                options.DefaultRequestCulture = new RequestCulture("de-DE");

                options.SupportedCultures = cultures;

                options.SupportedUICultures = cultures;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();

            app.UseRequestLocalization(options.Value);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Requests}/{action=Get}/{id?}");
            });
        }
    }
}
