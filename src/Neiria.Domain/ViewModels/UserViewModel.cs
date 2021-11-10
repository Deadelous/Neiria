using System;
using System.Collections.Generic;
using System.Text;

namespace Neiria.Domain.ViewModels
{
  public class UserViewModel
  {
    public Guid Guid { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public string PhoneNumber { get; set; }
  }
}
