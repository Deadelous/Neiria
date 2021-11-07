using Neiria.Domain.Interfaces;
using Neiria.Domain.Models;
using Neiria.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neiria.Infrastructure.Repositories
{
  public class BasketItemRepo : GenericRepo<BasketItem>, IBasketItemRepo, IDisposable
  {
    private readonly ClothContext _clothContext;

    public Guid ShoppingCartId { get; set; }


    public BasketItemRepo(ClothContext clothContext) : base(clothContext) {
      _clothContext = clothContext;
    }

    public async Task AddClothesInCart(Guid clothid)
    {
      ShoppingCartId = Guid.NewGuid();

      var cartItem = _clothContext.BasketItems.SingleOrDefault(
        item => item.CartId == ShoppingCartId 
      && item.ClothId == clothid);

      if(cartItem == null)
      {
        cartItem = new BasketItem
        {
          ClothId = Guid.NewGuid(),
          CartId = ShoppingCartId,
          Cloth = _clothContext.Clothes.SingleOrDefault(cloth => cloth.Guid == clothid),
          Quantity = 1
        };
        _clothContext.BasketItems.Add(cartItem);
      }
      else
      {
        cartItem.Quantity++;
      }
       _clothContext.SaveChanges();
    }

    public void Dispose()
    {
      if(_clothContext != null)
      {
        _clothContext.Dispose();
      }
    }

    public List<BasketItem> GetBasketItems()
    {
      ShoppingCartId = Guid.NewGuid();

      return _clothContext.BasketItems.Where(item => 
      item.CartId == ShoppingCartId).ToList();
    }
  }
}
