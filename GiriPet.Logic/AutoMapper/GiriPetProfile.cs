using AutoMapper;
using GiriPet.Data.Entities;
using GiriPet.Logic.Dtos;
using GiriPet.Logic.Enums;

namespace GiriPet.Logic.AutoMapper
{
    public class GiriPetProfile : Profile
    {
        public GiriPetProfile()
        {
            CreateMap<UserDM, UserDto>().ReverseMap();
            CreateMap<UserDM, UserRegisterDto>().ReverseMap();
            CreateMap<PetDM, PetDto>().ReverseMap();
            CreateMap<WalkerDM, WalkerDto>().ReverseMap();
            CreateMap<AppointmentDM, AppointmentDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (AppointmentStatus)src.StatusId))
                .ReverseMap();
            CreateMap<ReviewDM, ReviewDto>().ReverseMap();
            CreateMap<PaymentDM, PaymentDto>().ReverseMap();
        }
    }
}
