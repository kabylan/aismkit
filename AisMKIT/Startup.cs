using AisMKIT.Data;
using AisMKIT.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AisMKIT
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
            //Äëÿ Postgresql
            //services.AddDbContext<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options => //options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddRoles<IdentityRole>() // <--------                
            //       .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            //services.AddIdentity<ApplicationUser, IdentityRole>(config => config.SignIn.RequireConfirmedAccount = false)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //       services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            //       {
            //           options.User.RequireUniqueEmail = false;
            //       })
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();
            // services.AddIdentityCore<ApplicationUser>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IRepository, PhoneRepository>();


            //services.AddIdentity<User, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationContext>();

            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            //var logger = loggerFactory.CreateLogger("FileLogger");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                // logger.LogInformation("Processing request {0}", endpoints. context.Request.Path);
            });


        }
    }
}
