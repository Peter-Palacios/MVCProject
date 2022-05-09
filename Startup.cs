using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace MVCProject
{
    //og1
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

            services.AddScoped<IData, DBData>();

            services.AddDbContext<ReservationContext>(options => options.UseSqlServer("Server=DESKTOP-4KCJFM9;Database=MSSAReservations;" +
                "Trusted_Connection=True;MultipleActiveResultSets=True"));

            services.AddIdentity<User, IdentityRole>(options => //***
            {
                options.Password.RequiredLength = 8; //specify how want diff properties to be (req Up case, low case, digit, etc) if no specifiy, default characters will be used, or else can specify 

            }).AddEntityFrameworkStores<UserContext>();
            //18
            services.AddDbContext<UserContext>( //telling where db is going to be. telling appli this is server going to work w
                options => options.UseSqlServer("Server=DESKTOP-4KCJFM9;Database=MSSAResUsers;Trusted_Connection=True;MultipleActiveResultSets=True")

            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ReservationContext reservationContext,
            UserContext userContext, RoleManager<IdentityRole> roleManager)
        {

           // reservationContext.Database.EnsureDeleted();
           reservationContext.Database.EnsureCreated();

            userContext.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
