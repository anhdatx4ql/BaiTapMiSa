using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDomain;
using WebInfrastructure;

namespace WebApplication
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(Configuration["AllowOrigins"])
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddControllers();
            //services.RegisterServices();
            // Khai báo service
            services.AddScoped<IDapperRepository, DapperRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICarrerService, CarrerService>();
            services.AddScoped<ICustomerCareerService, CustomerCareerService>();
            services.AddScoped<IVocativeService, VocativeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ICustomerDetailService, CustomerDetailService>();
            services.AddScoped<ICustomerCareerService, CustomerCareerService>();
            services.AddScoped<ICustomerFieldService, CustomerFieldService>();
            services.AddScoped<ICustomerPotentialTypeService, CustomerPotentialTypeService>();
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<IOrganizationTypeService, OrganizationTypeService>();
            services.AddScoped<IPositionsService, PositionsService>();
            services.AddScoped<IPotentialTypeService, PotentialTypeService>();
            services.AddScoped<ISourceService, SourceService>();
            services.AddScoped<ITurnoverService, TurnoverService>();
            services.AddScoped<IFilesService, FilesService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // add cor
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
