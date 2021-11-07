using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neiria.Domain.Interfaces;
using Neiria.Domain.ViewModels;

namespace Neiria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
    private readonly IBasketItemRepo _repo;

    public BasketController(IBasketItemRepo repo)
    {
      _repo = repo;
    }

    [HttpPost("AddCloth")]
    [ProducesResponseType(typeof(BasketItemViewModel), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddClothesToCart([FromBody] BasketItemViewModel Basket)
    {
      try
      {
        var result = _repo.AddClothesInCart(Basket.ClothId);
        return StatusCode((int)HttpStatusCode.Created, result);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}
 