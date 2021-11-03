using Neiria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neiria.Domain.Interfaces
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
      Task<IEnumerable<T>> GetAll();

      Task<T> GetId(Guid id);

      Task<T> Insert(T ent);

      Task<T> Update(T ent);

      Task<T> Delete(Guid id);

  }
}
