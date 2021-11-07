using AutoMapper;
using Neiria.Domain.Models;
using Neiria.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neiria.Application.Profiles
{
  public class BasketItemProfile : Profile
  {
    public BasketItemProfile()
    {
      CreateMap<BasketItem, BasketItemViewModel>();
      CreateMap<BasketItemViewModel, BasketItem>();
    }
  }
}
