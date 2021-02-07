using AutoMapper;
using UserBL.ViewModels;
using UserDataAccess.Entities;

namespace Profiles
{
    public class MappingProfile : Profile {
        public MappingProfile() {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserVM>();
            CreateMap<UserVM, User>();
        }
    }
}