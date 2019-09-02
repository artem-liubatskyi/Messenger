using AutoMapper;
using Messenger.Data.Entities;
using Messenger.Web.Models;

namespace Messenger.Web.Mapping
{
    public class ServicesMapperProfile : Profile
    {
        public ServicesMapperProfile()
        {
            CreateMap<RegistrationViewModel, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(source => source.UserName))
                .ForMember(x => x.Email, opt => opt.MapFrom(source => source.Email))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(source => source.PhoneNumber));
        }
    }
}
