using JWT.Interface;
using JWT.Interfaces;
using JWT.Models;
using JWT.Service;
using JWT.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace JWT
{
    public sealed class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                       .AddJwtBearer(options =>
                       {
                           options.RequireHttpsMetadata = false;
                           options.TokenValidationParameters = new TokenValidationParameters
                           {
                               // укзывает, будет ли валидироваться издатель при валидации токена
                               ValidateIssuer = true,
                               // строка, представляющая издателя
                               ValidIssuer = AuthOptions.ISSUER,

                               // будет ли валидироваться потребитель токена
                               ValidateAudience = true,
                               // установка потребителя токена
                               ValidAudience = AuthOptions.AUDIENCE,
                               // будет ли валидироваться время существования
                               ValidateLifetime = true,

                               // установка ключа безопасности
                               IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                               // валидация ключа безопасности
                               ValidateIssuerSigningKey = true,
                           };
                       });


            services.AddControllersWithViews();
            services.AddMemoryCache();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "0.1",
                    Title = "API",
                    Description = "ASP.NET Core Web API ",

                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["GoogleClientId"];
                googleOptions.ClientSecret = Configuration["GoogleClientSecret"];
            }).AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["AppId"];
                facebookOptions.AppSecret = Configuration["AppSecret"];
            });

            //services.AddScoped<ExecuteService>();
            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IContextService, ContextService>();
            services.AddScoped<INewContextService, NewContextService>();
            services.TryAddScoped<ExecuteService>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
