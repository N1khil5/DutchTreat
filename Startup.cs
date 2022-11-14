using DutchTreat.Controllers;
using DutchTreat.Data;
using DutchTreat.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DutchTreat
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DutchContext>(cfg =>
            {
                cfg.UseSqlServer();
            });

            services.AddTransient<IMailService, NullMailService>();
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            services.AddRazorPages();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {

                cfg.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { Controller = "Pages", action = "Index" });

                cfg.MapRazorPages();
            });


            /*
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();*/
            app.Run();
        }
    }
}
