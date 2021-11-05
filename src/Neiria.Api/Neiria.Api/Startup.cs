using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Neiria.Application.Configuration;
using Neiria.Infrastructure.Context;

namespace Neiria.Api
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
      services.AddControllers();

      var connectionString = Configuration.GetConnectionString("connectionsqlite");

      services.AddDbContext<ClothContext>(options => options.UseSqlite(connectionString));

      services
         .AddDatabase()
         .AddRepositories();

      services.AddSwaggerGen();

      services.AddCors();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors(options =>
      {
        options.AllowAnyOrigin();
        options.AllowAnyHeader();
        options.AllowAnyMethod();
      });

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseSwagger(route => route.RouteTemplate = "api/swagger/{documentName}/swagger.json");

      app.UseSwaggerUI(ui =>
      {
        ui.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Neiria Api V1");
        ui.RoutePrefix = "api/swagger";
      });

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
