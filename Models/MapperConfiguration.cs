using AutoMapper;
using HarshaApi1.DTO;

namespace HarshaApi1.Models
{
    public class MapperConfiguration:Profile
    {
        public MapperConfiguration()
        {
            CreateMap<UserDetails, ApplicationUser>().ReverseMap();
        }
    }
}
