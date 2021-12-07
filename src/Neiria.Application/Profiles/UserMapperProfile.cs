using AutoMapper;
using Neiria.Domain.Models;
using Neiria.Domain.ViewModels;

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
