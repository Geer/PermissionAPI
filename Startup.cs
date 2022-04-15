using Microsoft.OpenApi.Models;
using PermissionAPI.DbModels;
using PermissionAPI.Repository;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PermissionAPI
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options
                => options.UseSqlServer("data source=.;initial catalog=permissions;Integrated Security=SSPI;TrustServerCertificate=True"));

            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();

            services.AddControllers();
            services.AddMvcCore()
                .AddJsonOptions(opions =>
                    opions.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddCors(options =>
            {
                options.AddPolicy(name: _defaultCorsPolicyName,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:8080")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithMethods("PUT", "POST", "DELETE", "GET");
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Permissions", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Permissions v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(_defaultCorsPolicyName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
