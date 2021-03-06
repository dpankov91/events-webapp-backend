using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Core.ApplicationService.Implementation;
using Events.Core.ApplicationService.Services;
using Events.Core.DomainService;
using Events.Infrastructure.Data;
using Events.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace eventsWebapp
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
            #region DB Settings
            services.AddDbContext<EventAppDBContext>(
                    opt =>
                    {
                        opt.UseSqlite("Data Source = eventApp.db");
                    });
            #endregion
            #region AddScoped
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanySQLRepository>();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonRepository, PersonSQLRepository>();

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository, EventSQLRepository>();

            services.AddTransient<IDataInitializer, DataInitializer>();
            #endregion
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eventsWebapp", Version = "v1" });
            });
            #endregion
            #region Ignore Loops
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            #endregion
            #region CORS
            services.AddCors(options => options.AddPolicy("AllowEverything", builder => builder.AllowAnyOrigin()
                                                                                               .AllowAnyMethod()
                                                                                               .AllowAnyHeader()));
            #endregion
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<EventAppDBContext>();
            var dataInitializer = scope.ServiceProvider.GetRequiredService<IDataInitializer>();

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            dataInitializer.SeedDB(ctx);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eventsWebapp v1"));
            }

            app.UseCors("AllowEverything");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
