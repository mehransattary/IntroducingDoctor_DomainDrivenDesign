using Common.Application;
using Doctor.Application.UserAgg.AddAddress;
using Doctor.Application.UserAgg.DeleteAddress;
using Doctor.Application.UserAgg.EditAddress;
using Doctor.Application.UserAgg.SetActiveAddress;
using Doctor.Query.UserAgg.DTOs;

namespace Doctor.Presentation.Facade.UserAgg.Addresses;

public interface IUserAddressFacade
{
    Task<OperationResult> AddAddress(AddUserAddressCommand command);

    Task<OperationResult> EditAddress(EditUserAddressCommand command);
    Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);

    Task<AddressDto?> GetById(long userAddressId);
    Task<List<AddressDto>> GetList(long userId);
    Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command);
}