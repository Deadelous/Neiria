using Neiria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neiria.Domain.Interfaces
{
  public interface IGenericRepo<Entity> where Entity : BaseEntity
  {
    Task<IEnumerable<Entity>> GetAll();

    Task<Entity> GetId(Guid id);

    Task<Entity> Insert(Entity ent);

    Task<Entity> Update(Guid id, Entity ent);

    Task Delete(Guid id);

  }
}
