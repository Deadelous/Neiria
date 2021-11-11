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

namespace Neiria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
    private readonly IUserRepo _repo;
    private readonly IMapper _mapper;

    public UserController(IUserRepo repo)
    {
      _repo = repo;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
      try
      {
        var users = await _repo.GetAll();
        return Ok(users);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<User>> GetSpecificUser(Guid id)
    {
      try
      {
        var result = await _repo.GetId(id);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpPost]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateNewUser([FromBody] User user)
    {
      try
      {
        var result = await _repo.Insert(user);
        return StatusCode((int)HttpStatusCode.Created, result);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
    {
      try
      {
        var result = await _repo.Update(id, user);
        return StatusCode((int)HttpStatusCode.Created, result);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
      try
      {
        await _repo.Delete(id);

        return NoContent();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}
  