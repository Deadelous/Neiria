using Neiria.Domain.Interfaces;
using Neiria.Domain.Models;
using Neiria.Infrastructure.Context;

namespace Neiria.Infrastructure.Repositories
{
  public class CatergoryRepo : GenericRepo<Catergory>, ICatergoryRepo
  {
    public CatergoryRepo(ClothContext clothContext) : base(clothContext) { }
  }
}
