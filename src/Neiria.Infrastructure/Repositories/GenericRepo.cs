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
      _context.Entry(ent).State = EntityState.Added;

      return ent;
    }

    public Task<T> Update(Guid id, T ent)
    {
      if (ent == null)
      {
        throw new ArgumentNullException("entity is null");
      }

      var result = _context.Set<T>().FirstOrDefaultAsync(ent => ent.Guid == id);

      _context.Entry(ent).State = EntityState.Modified;

      return Task.FromResult(ent);
      
    }
  }
}
