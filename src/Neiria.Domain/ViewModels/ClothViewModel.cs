using System;
using System.Collections.Generic;
using System.Text;

namespace Neiria.Domain.ViewModels
{
  public class ClothViewModel
  {
    public Guid Guid { get; set; }

    public string Name { get; set; }

    public string BrandName { get; set; }

    public double Price { get; set; }

    public string Description { get; set; }
  }
}
