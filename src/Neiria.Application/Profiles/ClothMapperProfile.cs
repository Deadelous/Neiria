using AutoMapper;
using Neiria.Domain.Models;
using Neiria.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neiria.Application.Profiles
{
  public class ClothMapperProfile : Profile
  {
    public ClothMapperProfile()
    {
      CreateMap<Cloth, ClothViewModel>();
      CreateMap<ClothViewModel, Cloth>();
    }
  }
}
