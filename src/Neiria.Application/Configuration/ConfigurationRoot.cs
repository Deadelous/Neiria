using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neiria.Domain.Interfaces;
using Neiria.Infrastructure.Context;
using Neiria.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neiria.Application.Configuration
{
  public static class ConfigurationRoot
  {
    public static IConfiguration Configuration { get; }

    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
      services.AddTransient<Func<ClothContext>>((provider) => () => provider.GetService<ClothContext>());

      return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {

      return services
        .AddTransient(typeof(IGenericRepo<>), typeof(GenericRepo<>))
        .AddTransient<IClothRepo, ClothRepo>()
        .AddTransient<ICatergoryRepo, CatergoryRepo>();
    }
  }
}
