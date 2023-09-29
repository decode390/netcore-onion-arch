using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities;
using Domain.Common;
using System.Reflection;

namespace Persistence.Contexts
{
    public class ApplicationDbContext: DbContext
   {
      private readonly IDateTimeService _dateTime;
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime): base(options)
      {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; 
        this._dateTime = dateTime;
      } 
      public DbSet<Client> Clients { get; set; }

      public override Task<int> SaveChangesAsync(CancellationToken cancellationToken){
        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
        {
          switch (entry.State)
          {
            case EntityState.Added:
              entry.Entity.Created = _dateTime.NowUtc;
              entry.Entity.CreatedBy = "";
              entry.Entity.LastModifiedBy = "";
              break;
            case EntityState.Modified:
              entry.Entity.LastModified = _dateTime.NowUtc;
              entry.Entity.CreatedBy = "";
              entry.Entity.LastModifiedBy = "";
              break;
          } 
        } 
        return base.SaveChangesAsync(cancellationToken);
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      }
   } 
}
