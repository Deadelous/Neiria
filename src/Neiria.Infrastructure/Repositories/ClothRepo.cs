using Neiria.Domain.Interfaces;
using Neiria.Domain.Models;
using Neiria.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neiria.Infrastructure.Repositories
{
  public class ClothRepo : GenericRepo<Cloth>, IClothRepo
  {
  
    public ClothRepo(ClothContext clothContext) : base(clothContext) { }
  }
}
