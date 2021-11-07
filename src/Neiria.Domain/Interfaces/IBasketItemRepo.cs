using Neiria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neiria.Domain.Interfaces
{
  public interface IBasketItemRepo : IGenericRepo<BasketItem>
  {
    Task AddClothesInCart(Guid id);

    List<BasketItem> GetBasketItems();
  }
}
