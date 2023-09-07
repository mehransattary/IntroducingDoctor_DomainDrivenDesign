﻿using Common.Application;
using Doctor.Domain.UserAgg.Repository;

namespace Doctor.Application.UserAgg.DeleteAddress;

public class DeleteUserAddressCommandHandler : IBaseCommandHandler<DeleteUserAddressCommand>
{
    private readonly IUserRepository _repository;

    public DeleteUserAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        user.DeleteAddress(request.AddressId);

        await _repository.Save();
        return OperationResult.Success();
    }
}