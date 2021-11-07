using System;
using System.Collections.Generic;
using System.Text;

namespace Neiria.Domain.Models
{
  public class BasketItem : BaseEntity
  {
    public Guid CartId { get; set; }

    public int Quantity { get; set; }

    public Guid ClothId { get; set; }

    public virtual Cloth Cloth { get; set; }
  }
}
