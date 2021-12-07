using Microsoft.EntityFrameworkCore;
using Neiria.Domain.Interfaces;
using Neiria.Domain.Models;
using Neiria.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neiria.Infrastructure.Repositories
{
  public class GenericRepo<Entity> : IGenericRepo<Entity> where Entity : BaseEntity
  {
    private readonly ClothContext _context;
    private DbSet<Entity> entities;

    public GenericRepo(ClothContext context)
    {
      _context = context;
      entities = context.Set<Entity>();
    }

    public async Task Delete(Guid id)
    {
      Entity ent = await entities.SingleAsync(e => e.Guid == id);

      _context.Remove(ent);

      _context.SaveChanges();
    }

    public async Task<IEnumerable<Entity>> GetAll()
    {
      return await entities.ToListAsync();
    }


    public async Task<Entity> GetId(Guid id)
    {
      return await entities.SingleOrDefaultAsync(e => e.Guid == id);
    }

    public async Task<Entity> Insert(Entity ent)
    {
      if (ent == null) throw new ArgumentNullException("There is no value");

      await entities.AddAsync(ent);
      _context.SaveChanges();
      _context.Entry(ent).State = EntityState.Added;

      return ent;
    }

    public Task<Entity> Update(Guid id, Entity ent)
    {
      if (ent == null)
      {
        throw new ArgumentNullException("entity is null");
      }

      _context.Set<Entity>().Update(ent);

      _context.SaveChanges();

      return Task.FromResult(ent);

    }
  }
}
