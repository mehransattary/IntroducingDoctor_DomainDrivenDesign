using AutoMapper;
using Doctor.Api.ViewModels.Users;
using Doctor.Application.UserAgg.AddAddress;
using Doctor.Application.UserAgg.ChangePassword;

namespace Doctor.Api.Infrastructure;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AddUserAddressCommand, AddUserAddressViewModel>()
            .ForMember(f => f.PhoneNumber, r => r.MapFrom(w => w.PhoneNumber)).ReverseMap();

        CreateMap<ChangePasswordViewModel, ChangeUserPasswordCommand>().ReverseMap();
    }
}