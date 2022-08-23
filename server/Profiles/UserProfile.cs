using AutoMapper;
using server.Entities;
using server.Models;

namespace server.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserToCreateDto, User>();
            CreateMap<UserToUpdateDto, User>();

        }

    }
}
