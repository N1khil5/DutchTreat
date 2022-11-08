using DutchTreat.Controllers;

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
            //services.AddRazorPages();
            services.AddControllersWithViews();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { Controller = "App", action = "Index" });
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
