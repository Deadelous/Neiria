using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Neiria.Api.Controllers;
using Neiria.Domain.Models;
using Neiria.Domain.ViewModels;
using Neiria.Tests.FakeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Neiria.Tests
{
  public class Clothes_CRUD_Tests
  {
    private readonly ClothesController _controller;
    private readonly ClothesRepoFake _sut;
    private readonly IMapper _mapper;

    public Clothes_CRUD_Tests()
    {
      _sut = new ClothesRepoFake();

      _controller = new ClothesController(_sut, _mapper);

    }

    [Fact]
    public async void Test_Read_GetAllItems_Returns_AllItems()
    {
      // Act
      IEnumerable<Cloth> result = await _sut.GetAll();

      List<Cloth> total = Assert.IsType<List<Cloth>>(result);

      // Assert

      Assert.Equal(3, total.Count);

    }

    [Fact]
    public async void Test_Read_GetId_Return_OkResult()
    {
      // Act
      Cloth clothitem = new Cloth { Guid = new Guid("6299982f-4069-44f6-b88a-840da3ec38ec"), Name = "Vest", BrandName = "C&A", Price = 15 };

      await _sut.Insert(clothitem);

      Guid getClothId = clothitem.Guid;

      Cloth result = await _sut.GetId(getClothId);

      // Assert
      Assert.NotNull(result);
      Assert.IsType<Cloth>(result);
    }

    [Fact]
    public async void Test_Create_Insert_ReturnsValid()
    {
      // Act
      ClothViewModel clothitem = new ClothViewModel { Name = "Vest", BrandName = "C&A", Price = 15 };

      var result = await _controller.CreateNewCloth(clothitem);

      // Assert
      Assert.NotNull(result);
      Assert.IsType<ObjectResult>(result);

    }

    [Fact]
    public async void Test_Delete_Return_NoContentResult()
    {
      // Act
      Guid item = new Guid("6299982f-4069-44f6-b88a-840da3ec38ec");

      ActionResult okRespone = await _controller.DeleteCloth(item);

      // Assert

      Assert.IsType<NoContentResult>(okRespone);
    }

    [Fact]
    public async void Test_Read_GetId_Return_NotFound()
    {
      Guid notfoundId = Guid.NewGuid();

      Cloth result = await _sut.GetId(notfoundId);

      Assert.Null(result);
    }

    [Fact]
    public async void Test_Create_Insert_Null()
    {
      ClothViewModel result = null;

      var nocontent = await _controller.CreateNewCloth(result);

      Assert.IsType<ObjectResult>(nocontent);
    }
  }
}
