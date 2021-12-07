using Neiria.Domain.Interfaces;
using Neiria.Domain.Models;
using Neiria.Infrastructure.Context;


namespace Neiria.Infrastructure.Repositories
{
  public class UserRepo : GenericRepo<User>, IUserRepo
  {
    public UserRepo(ClothContext context) : base(context){ }
  }
}
