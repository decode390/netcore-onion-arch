using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using Application.Interfaces;

namespace Persistence
{
  public static class ServiceExtensions
  {
      public static void  AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration config) {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
              config.GetConnectionString("DefaultConnection"),
              b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
              ));

        #region Repositories
        services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
            
        #endregion
      }
  }
}
