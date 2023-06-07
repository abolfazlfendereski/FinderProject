using AutoMapper;
using EndPoint.FinderProject.HelpService.UploadImage;
using IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using FinderProject.Domian.Dto;
using FinderProject.Domian.Entities;
using FinderProject.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using EndPoint.FinderProject.Models.EmailClasses;
using EndPoint.FinderProject.HelpService.EmailService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;

namespace EndPoint.FinderProject
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
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("LogFile/Logging")
            .WriteTo.Console()
            .MinimumLevel.Error()
            .CreateLogger();
            services.AddIdentity<User, IdentityRole>(option =>
            {
                option.Lockout.AllowedForNewUsers = true;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(option =>
            {
                option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/account/google-login"; 
            })
            .AddGoogle(GoogleDefaults.AuthenticationScheme, option =>
              {
                  option.ClientId = "999484218181-d84hoctgktecstl9ga8ajpcdg7jkcthb.apps.googleusercontent.com";
                  option.ClientSecret = "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";
                  //option.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
              });
            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic }));//For support launguage farsi in notification
            object p = services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDBContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Con")));
            services.AddScoped<IUploadImage, UploadImage>();
            services.AddAutoMapper(typeof(Startup));
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = "Localhost:6379";
            });
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddScoped<IEmailService, EmailService>();
            RegisterService(services);
            services.AddControllersWithViews();
        }
        public static void RegisterService(IServiceCollection services)
        {
            DependencyContainer.RegisterService(services);
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
