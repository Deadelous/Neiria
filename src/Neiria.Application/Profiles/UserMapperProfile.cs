using AutoMapper;
using Neiria.Domain.Models;
using Neiria.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neiria.Application.Profiles
{
  public class UserMapperProfile : Profile
  {
    public UserMapperProfile()
    {
      CreateMap<User, UserViewModel>();
      CreateMap<UserViewModel, User>();
    }
  }
}
