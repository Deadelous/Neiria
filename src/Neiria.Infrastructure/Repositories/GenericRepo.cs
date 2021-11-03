using Neiria.Domain.Interfaces;
using Neiria.Domain.Models;
using Neiria.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neiria.Infrastructure.Repositories
{
  public class GenericRepo : IGenericRepo<Cloth>
  {
    private readonly ClothContext _context;

    public GenericRepo(ClothContext context)
    {
      _context = context;
    }
    public Task<Cloth> Delete(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Cloth>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<Cloth> GetId(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<Cloth> Insert(Cloth ent)
    {
      throw new NotImplementedException();
    }

    public Task<Cloth> Update(Cloth ent)
    {
      throw new NotImplementedException();
    }
  }
}
