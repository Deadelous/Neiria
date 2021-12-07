using Neiria.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neiria.Domain.Interfaces
{
  public interface IClothRepo : IGenericRepo<Cloth>
  {
    Task<IEnumerable<Cloth>> GetAllOrderByName();

    Task<IEnumerable<Cloth>> GetAllOrderByPrice();
  }
}
