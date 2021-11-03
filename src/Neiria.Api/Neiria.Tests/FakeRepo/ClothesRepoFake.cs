using Neiria.Domain.Interfaces;
using Neiria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neiria.Tests.FakeRepo
{
  public class ClothesRepoFake : IClothRepo
  {
    private readonly List<Cloth> _fakeClothes;

    public ClothesRepoFake()
    {
      _fakeClothes = new List<Cloth>()
      {
        new Cloth()
        {
          Guid = new Guid("6299982f-4069-44f6-b88a-840da3ec38ec"),
          Name = "Zwarte T-shirt",
          BrandName = "Tommy Hilfiger",
          Price = 4.99
        },
        new Cloth()
        {
          Guid = new Guid("a18ab0d3-2122-401a-a183-6dad872e3606"),
          Name = "Slim Jeans",
          BrandName = "Jeans Center Classic",
          Price = 22
        },
        new Cloth()
        {
          Guid = new Guid("be9a4ebb-6144-48ca-8b11-e7a193f80653"),
          Name = "Matrozenpak XL",
          BrandName = "Zeeman",
          Price = 199
        }
      };
    }
    public Task Delete(Guid id)
    { 
      var existingItem =_fakeClothes.First(e => e.Guid == id);
      _fakeClothes.Remove(existingItem);

      return Task.CompletedTask;
    }

    public Task<IEnumerable<Cloth>> GetAll()
    {
      return Task.FromResult(_fakeClothes.AsEnumerable());
    }

    public Task<Cloth> GetId(Guid id)
    {
      return Task.FromResult(_fakeClothes.FirstOrDefault(e => e.Guid == id));
    }

    public Task<Cloth> Insert(Cloth ent)
    {
      _fakeClothes.Add(ent);
      return Task.FromResult(ent);
    }

    public Task<Cloth> Update(Guid id, Cloth ent)
    {
      var item = _fakeClothes.Find(e => e.Guid == id);

      return Task.FromResult(item);

      
    }
  }
}
