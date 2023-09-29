using System;
using Ardalis.Specification.EntityFrameworkCore;
using Application.Interfaces;
using Persistence.Contexts;

namespace Persistence.Repositories
{
  public class MyRepositoryAsync<T>: RepositoryBase<T>, IRepositoryAsync<T> where T:class
  {
    private readonly ApplicationDbContext _dbContext;
    public MyRepositoryAsync(ApplicationDbContext dbContext): base(dbContext)
    {
      this._dbContext = dbContext; 
    }
  } 
}
