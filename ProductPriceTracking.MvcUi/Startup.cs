using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductPriceTracking.Bll.ComplexTypes;
using ProductPriceTracking.MvcUi.Containers.MicrosoftIOC;
using System;

namespace ProductPriceTracking.MvcUi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAllDependencies(Configuration);
            services.AddControllersWithViews().AddCustomControllerServices();
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider,IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseSession();

            SeedDatabase.Seed(serviceProvider).Wait();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=SignIn}/{id?}");
            });
        }
    }
}
