using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCore.BLL.Interfaces;
using SCore.BLL.Services;
using SCore.DAL.EF;
using SCore.DAL.Interfaces;
using SCore.DAL.Repositories;
using SCore.Models;
using SCore.Models.Entities;
  
namespace SCore.WEB
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IRepository<Product>, ProductRepository >();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IEmailSender, EmailService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddIdentity<User, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpContextAccessor();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = "405558759348-k91mpnp7r8vmmqsvcgii0uek2affej8b.apps.googleusercontent.com";
                    googleOptions.ClientSecret = "SXtEzIDr3XJjj0uHzGpNU7Hv";

                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/LogIn";

                });

            services.AddMemoryCache();
            services.AddSession();
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
           
        }
    }
}
