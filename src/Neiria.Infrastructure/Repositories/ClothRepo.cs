using Microsoft.EntityFrameworkCore;
using Neiria.Domain.Interfaces;
using Neiria.Domain.Models;
using Neiria.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neiria.Infrastructure.Repositories
{
  public class ClothRepo : GenericRepo<Cloth>, IClothRepo
  {
    private readonly ClothContext _clothContext;
    public ClothRepo(ClothContext clothContext) : base(clothContext) {
      _clothContext = clothContext;
    }

    public async Task<IEnumerable<Cloth>> GetAllOrderByName()
    {
      return await _clothContext.Clothes.OrderBy(cloth => cloth.Name).ToListAsync();
    }

    public async Task<IEnumerable<Cloth>> GetAllOrderByPrice()
    {
      return await _clothContext.Clothes.OrderBy(cloth => cloth.Price).ToListAsync();
    }
  }
}
