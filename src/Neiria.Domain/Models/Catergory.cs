using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Neiria.Domain.Models
{

  [Table("Catergories")]
  public class Catergory : BaseEntity
  {
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

  }
}
