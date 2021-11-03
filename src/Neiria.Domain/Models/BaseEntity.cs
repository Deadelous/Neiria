using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Neiria.Domain.Models
{
    public class BaseEntity
    {
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
     [Key]
      public Guid Guid { get; set; }

      public DateTime CreatedAt { get; set; }

      public DateTime UpdatedAt { get; set; }
    }
}
