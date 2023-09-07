using Common.Query;
using Doctor.Query.UserAgg.DTOs;

namespace Doctor.Query.UserAgg.Addresses.GetList;

public record GetUserAddressesListQuery(long UserId) : IQuery<List<AddressDto>>;