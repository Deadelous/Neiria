using Neiria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neiria.Domain.ViewModels
{
  public class BasketItemViewModel
  {
    public string ItemId { get; set; }

    public string CartId { get; set; }

    public int Quantity { get; set; }

    public Guid ClothId { get; set; }

    public virtual Cloth Cloth { get; set; }
  }
}
