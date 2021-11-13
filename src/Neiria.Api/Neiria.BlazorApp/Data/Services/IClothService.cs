using Neiria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neiria.BlazorApp.Data.Services
{
  public interface IClothService
  {
    Task<IEnumerable<Cloth>> GetAllClothes();

    Task<Cloth> GetSpecificCloth(Guid id);

    Task<Cloth> CreateNewCloth(Cloth cloth);
  }
}
