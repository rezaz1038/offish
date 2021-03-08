using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoftIran.DataLayer.Models.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using SoftIran.DataLayer.Models.Entities;
using SoftIran.Application.Services;
using SoftIran.Application.Services.IService;

using AutoMapper;
using SoftIran.Application.Profiles;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace SoftIran.Web
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
            #region Database Context
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DeflautString"));

            });
            #endregion

            #region identity

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDBContext>()
               .AddDefaultTokenProviders();

            #endregion


            #region IReopsitory Service
            services.AddTransient<IDepartment, DepartmentService>();
            services.AddTransient<IEquipment, EquipmentService>();
            services.AddTransient<IEquipmentPlace, EquipmentPlaceService>();
            services.AddTransient<IEquipmentType, EquipmentTypeService>();
            services.AddTransient<IEquipmentBrand, EquipmentBrandService>();
            services.AddTransient<IPgm, PgmService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IOffishCategory, OffishCategoryService>();
            services.AddTransient<IOffishUpsert, OffishUpsertService>();

            #endregion


            #region Automapper
            services.AddAutoMapper(typeof(EquipmentProfile));
            services.AddAutoMapper(typeof(IdentityProfile));
            #endregion

            #region Autentication
            var TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                // ValidAudience = "",
                // ValidIssuer = "",
                RequireExpirationTime = false,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                ValidateIssuerSigningKey = true
            };

            services.AddSingleton(TokenValidationParameters);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => options.TokenValidationParameters = TokenValidationParameters);

            #endregion


            #region Authorization
            services.AddAuthorization();
            #endregion
            //services.AddApiVersioning();
             #region  API Versioning
            services.AddApiVersioning(x =>
            {
               x.DefaultApiVersion = new ApiVersion(1, 0);
               x.AssumeDefaultVersionWhenUnspecified = false;
               x.ReportApiVersions = true;
               x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
            });
             #endregion



            services.AddSwaggerGen();

            services.AddMvc(
                option => option.EnableEndpointRouting = false
                );
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();
            app.UseMvc();



            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
