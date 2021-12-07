using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neiria.Domain.Interfaces;
using Neiria.Domain.Models;
using Neiria.Domain.ViewModels;
using Neiria.Infrastructure.Repositories;

namespace Neiria.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClothesController : ControllerBase
  {
    private readonly IClothRepo _repo;
    private readonly IMapper _mapper;

    public ClothesController(IClothRepo repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ClothViewModel>),(int) HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ClothViewModel>>> GetClothes()
    {
      try 
      {
        var items = await _repo.GetAll();
        var mapItems = _mapper.Map<IEnumerable<ClothViewModel>>(items);
        return Ok(mapItems);
      }
      catch (Exception ex) {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpGet("OrderbyName")]
    [ProducesResponseType(typeof(IEnumerable<ClothViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ClothViewModel>>> GetClothesSortyByName()
    {
      try
      {
        var items = await _repo.GetAllOrderByName();
        var mapItems = _mapper.Map<IEnumerable<ClothViewModel>>(items);
        return Ok(mapItems);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpGet("OrderbyPrice")]
    [ProducesResponseType(typeof(IEnumerable<ClothViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ClothViewModel>>> GetClothesSortyByPrice()
    {
      try
      {
        var items = await _repo.GetAllOrderByPrice();
        var mapItems = _mapper.Map<IEnumerable<ClothViewModel>>(items);
        return Ok(mapItems);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ClothViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ClothViewModel>> GetSpecificCloth(Guid id)
    {
      try
      {
        Cloth result = await _repo.GetId(id);
        ClothViewModel mapResult = _mapper.Map<ClothViewModel>(result);
        return Ok(mapResult);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    [ProducesResponseType(typeof(ClothViewModel), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateNewCloth([FromBody] ClothViewModel cloth) 
    {
      try   
      {
        Cloth result = await _repo.Insert(_mapper.Map<Cloth>(cloth));
        ClothViewModel mapResult = _mapper.Map<ClothViewModel>(result);
        return StatusCode((int)HttpStatusCode.Created, mapResult);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ClothViewModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateCloth(Guid id, [FromBody] ClothViewModel cloth)
    {
      try
      {
        var result = await _repo.Update(id , _mapper.Map<Cloth>(cloth));
        var mapResult = _mapper.Map<ClothViewModel>(result);
        return StatusCode((int)HttpStatusCode.Created, mapResult);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> DeleteCloth(Guid id)
    {
      try
      {
        await _repo.Delete(id);

        return NoContent();
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }
  }
}