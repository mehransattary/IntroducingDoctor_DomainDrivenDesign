using Common.Application;

namespace Doctor.Application.UserAgg.DeleteAddress;

public record DeleteUserAddressCommand(long UserId, long AddressId) : IBaseCommand;