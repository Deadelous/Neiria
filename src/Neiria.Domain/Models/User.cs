using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Neiria.Domain.Models
{

  [Table("Users")]
  public class User : BaseEntity
  {
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public int Age { get; set; }

    public string PhoneNumber { get; set; }
  }
}
