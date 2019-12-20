using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RastgeleFilm.Models;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace RastgeleFilm
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
            //Veritabaný baðlantýsý.
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddControllers(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            // Çevirilerin yer alacaðý klasörü belirtiyoruz.
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization();
            //Özel bir saðlayýcý
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("tr-TR"),                    
                    new CultureInfo("en-US"),                                                        
                };

                options.DefaultRequestCulture = new RequestCulture("tr-TR");
                // Formatting numbers, dates, etc.
                options.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                options.SupportedUICultures = supportedCultures;

            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Yeni eklendi.
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);



            app.UseRouting();
            //Authentication eklendi.
            app.UseAuthentication();
            app.UseAuthorization();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
            "admin",
            "admin",
            "Admin/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    "default", "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //Yeni eklendi.
                endpoints.MapRazorPages();
            });
        }
    }
}
