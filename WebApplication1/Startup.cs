using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dotMovies.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using dotMovies.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using dotMovies.Helpers.Converters;

namespace dotMovies
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
            services.AddMvc().
                AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter()));

            services.AddRazorPages();
            services.AddHealthChecks();

            services.AddTransient<MoviesService>();
            services.AddTransient<UsersService>();

            services.AddDbContext<MoviesDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MoviesDBContext")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();

            // /...
            endpoints.MapControllerRoute(
               name: "home",
               pattern: "{action}/{id?}",
               defaults: new { controller = "Home", action = "Index" }
               );
            
            // user/...
            endpoints.MapControllerRoute(
                name: "user",
                pattern: "{controller}/{action}",
                defaults: new { controller = "User", action = "Register" }
                );

            // api/...
            endpoints.MapControllers();

            });
        }
    }
}
