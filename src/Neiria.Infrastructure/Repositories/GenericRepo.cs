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

    public GenericRepo(ClothContext context)
    {
      _context = context;
    }

    public Task<T> Delete(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<T> GetId(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<T> Insert(T ent)
    {
      throw new NotImplementedException();
    }

    public Task<T> Update(T ent)
    {
      throw new NotImplementedException();
    }
  }
}
