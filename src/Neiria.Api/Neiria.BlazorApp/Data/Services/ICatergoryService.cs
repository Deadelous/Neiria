using Neiria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neiria.BlazorApp.Data.Services
{
  public interface ICatergoryService
  {
    Task<IEnumerable<Catergory>> GetAllCatergories();
  }
}
