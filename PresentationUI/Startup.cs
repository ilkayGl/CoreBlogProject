using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using PresentationUI.Helpers;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace PresentationUI
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
            //configuration-Db
            //services.AddDbContext<Context>(opsions => opsions.UseSqlServer(Configuration.GetConnectionString("DbContext"))); 
            

            services.AddControllersWithViews();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy)); // todo Proje-level-Authorization
            });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("A", policy => policy.RequireClaim(ClaimTypes.Role));
            //});



            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })

                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Login/Index");//Authentication

                })
                .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
                {
                    options.ClientId = Configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                    options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
                });


            //ToastrNotyf
            services.AddNotyf(config =>
            {
                config.DurationInSeconds = 10;
                config.IsDismissable = true;
                config.Position = NotyfPosition.BottomRight;
            });

            //AutoMapper
            services.AddAutoMapper(c => c.AddProfile<AutoMapperProfiles>(), typeof(Startup));

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
                //app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Page404", "?code={0}"); //ErrorPage

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization(); //

            app.UseAuthentication(); //

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}"); //Areas PageMap


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");
            });
        }
    }
}
