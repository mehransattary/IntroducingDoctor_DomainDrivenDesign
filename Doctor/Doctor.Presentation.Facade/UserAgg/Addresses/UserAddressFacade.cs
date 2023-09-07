using Common.Application;
using Doctor.Application.UserAgg.AddAddress;
using Doctor.Application.UserAgg.DeleteAddress;
using Doctor.Application.UserAgg.EditAddress;
using Doctor.Application.UserAgg.SetActiveAddress;
using Doctor.Query.UserAgg.Addresses.GetById;
using Doctor.Query.UserAgg.Addresses.GetList;
using Doctor.Query.UserAgg.DTOs;
using MediatR;


namespace Doctor.Presentation.Facade.UserAgg.Addresses;

internal class UserAddressFacade : IUserAddressFacade
{
    private readonly IMediator _mediator;

    public UserAddressFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddAddress(AddUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditAddress(EditUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<AddressDto?> GetById(long userAddressId)
    {
        return await _mediator.Send(new GetUserAddressByIdQuery(userAddressId));

    }

    public async Task<List<AddressDto>> GetList(long userId)
    {
        return await _mediator.Send(new GetUserAddressesListQuery(userId));
    }

    public async Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command)
    {
        return await _mediator.Send(command);
    }
}