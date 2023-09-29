using System;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Shared.Services;

namespace Shared
{
  public static class ServiceExtensions
  {
    public static void AddSharedInfrastructure(this IServiceCollection services){
      #region Shared
        services.AddTransient<IDateTimeService, DateTimeService>(); 
      #endregion
    }

  }
}
