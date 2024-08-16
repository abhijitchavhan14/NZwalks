using AutoMapper;

namespace ASP.NET_Core_Web_API__1.Profiles
{
    public class RegionsProfile:Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region,Models.DTO.Region>();
        }
    }
}
