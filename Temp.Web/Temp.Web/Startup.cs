using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Temp.DataAccess;
using Temp.Service.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Temp.Common.Infrastructure;
using Temp.Service.BaseService;
using Temp.Service.Mapper;
using Temp.Web.Infacestructure.Middlewares;
using Serilog;
using Temp.DataAccess.Data;
using Temp.Web.Infacestructure.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Temp.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            //connect data
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));           

            //add scope
            services.AddScoped<IUnitofWork, UnitofWork>();           
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ExtensionRequestFilter>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<INsxService, NsxService>();

            //mapper
            services.AddAutoMapper(typeof(UserMapping));
            services.AddAutoMapper(typeof(CategoryMapping));
            services.AddAutoMapper(typeof(NsxMapping));
            services.AddAutoMapper(typeof(RoleMapping));

            //authentication
            services.AddAuthentication(options =>
                {
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(option =>
                {                   
                    option.AccessDeniedPath = Constants.Route.AccessDenied;
                });
            
            services.AddSession(options =>
            {
                options.Cookie.Name = Constants.AppSession;
                options.IdleTimeout = TimeSpan.FromMinutes(Convert.ToDouble(Configuration[Constants.Settings.ExpiredSessionTime] ?? "60"));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireAssertion(context => context.User.IsInRole(Constants.Role.Admin)));
                options.AddPolicy("Manager", policy => policy.RequireAssertion(context => 
                context.User.IsInRole(Constants.Role.Manager) || context.User.IsInRole(Constants.Role.Admin)));
            });
            
            
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration[Constants.JwtIssuer],
                    ValidAudience = Configuration[Constants.JwtIssuer],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[Constants.JwtKey]))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }
            else
            {
                app.UseExceptionHandler(Constants.Route.ErrorPage);
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseSession();

            //config middleware
            app.UseNotFound();
            app.UseMiddleware<NotPermissionMiddleware>();
                       
            loggerFactory.AddSerilog();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=LogIn}/{id?}");
            });
        }
    }
}
