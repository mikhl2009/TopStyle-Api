using AutoMapper;
using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;
using TopStyle_Api.Domain.Identity;

namespace TopStyle_Api.Domain.Profiles
{
    public class UserProfile : Profile
    {

        public UserProfile() 
        {
            CreateMap<UserRegisterDTO, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserLoginDTO, ApplicationUser>();
            CreateMap<ApplicationUser, UserLoginDTO>();

        }
    }
}
