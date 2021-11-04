using Microsoft.EntityFrameworkCore;
using Neiria.Domain.Interfaces;
using Neiria.Domain.Models;
using Neiria.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neiria.Infrastructure.Repositories
{
  public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
  {
    private readonly ClothContext _context;
    private DbSet<T> entities;

    public GenericRepo(ClothContext context)
    {
      _context = context;
      entities = context.Set<T>();
    }

    public async Task Delete(Guid id)
    {
      T ent = await entities.SingleAsync(e => e.Guid == id);

      _context.Remove(ent);

      _context.SaveChanges();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
      return await entities.ToListAsync();
    }

    public async Task<T> GetId(Guid id)
    {
      return await entities.SingleOrDefaultAsync(e => e.Guid == id);
    }

    public async Task<T> Insert(T ent)
    {
      await entities.AddAsync(ent);
      _context.SaveChanges();
      _context.Entry(ent).State = EntityState.Added;

      return ent;
    }

    public Task<T> Update(Guid id, T ent)
    {
      if (ent == null)
      {
        throw new ArgumentNullException("entity is null");
      }

      _context.Set<T>().Update(ent);

      _context.SaveChanges();

      return Task.FromResult(ent);

    }
  }
}
