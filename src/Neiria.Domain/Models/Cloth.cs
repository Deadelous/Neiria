using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Neiria.Domain.Models
{
  [Table("Clothes")]
  public class Cloth : BaseEntity
  {
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(20)]
    public string BrandName { get; set; }

    [Required]
    public double Price { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

  }
}
