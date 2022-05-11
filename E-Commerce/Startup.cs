using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.RepositoryLayer;
using Ecommerce.RepositoryLayer.repositories;
using ServiceLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.services;
using Microsoft.AspNetCore.Identity;
using Ecommerce.DomainLayer.models;

namespace E_Commerce
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
            #region Sessions
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(20);//You can set Time   
            });
            #endregion
            #region Add Database
            services.AddDbContext<DataContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = false;
                }
                )
                .AddEntityFrameworkStores<DataContext>()
              .AddDefaultTokenProviders().AddDefaultUI();
            services.AddRazorPages();


            #endregion
            #region Register Dependancies
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IMainCategoryServices), typeof(MainCategoryServices));
            services.AddScoped(typeof(ISupCategoryServices), typeof(SupCategoryServices));
            services.AddScoped(typeof(ICartServices), typeof(CartServices));
            services.AddHealthChecks();
            #endregion
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
            }
            app.UseStaticFiles();
         

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages(); 
            });
        }
    }
}
