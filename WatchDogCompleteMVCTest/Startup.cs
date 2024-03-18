using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchDog;
using WatchDog.src.Enums;

namespace WatchDogCompleteMVCTest
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
            services.AddControllersWithViews();
            services.AddWatchDogServices();
            services.AddWatchDogServices(opt => { 
                opt.IsAutoClear = true;
                opt.SqlDriverOption = WatchDog.src.Enums.WatchDogSqlDriverEnum.PostgreSql;
                opt.SetExternalDbConnString = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=postgres;SearchPath=dbwatchdog;";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseWatchDogExceptionLogger();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMvcWithDefaultRoute();

            app.UseWatchDog(opt => { 
                opt.WatchPageUsername = "admin"; 
                opt.WatchPagePassword = "admin123"; 
                opt.Blacklist = "Test/testPost, weatherforecast"; 
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
