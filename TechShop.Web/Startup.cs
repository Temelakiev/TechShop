namespace TechShop.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TechShop.Data;
    using TechShop.Data.Models;
    using AutoMapper;
    using TechShop.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services;
    using TechShop.Services.Implementations.ShoppingCarts;
    using TechShop.Services.Admin;
    using TechShop.Services.Admin.Implementations;
    using TechShop.Services.Implementations.Categories;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using TechShop.Services.Implementations.Products;
    using System.Net.Http;
    using TechShop.Services.Html;
    using TechShop.Services.Html.Implementations;
    using TechShop.Services.Moderator;
    using TechShop.Services.Moderator.Implementations;
    using TechShop.Services.Implementations.Comments;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            services.AddDbContext<TechShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<TechShopDbContext>()
                .AddDefaultTokenProviders();

            services.AddSession();

            services.AddSingleton<IShoppingCartManager, ShoppingCartManager>();


            services.AddAutoMapper();

            services.AddDomainServices();

            services.AddRouting(routing => routing.LowercaseUrls = true);

            services.AddMvc(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSession();

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
