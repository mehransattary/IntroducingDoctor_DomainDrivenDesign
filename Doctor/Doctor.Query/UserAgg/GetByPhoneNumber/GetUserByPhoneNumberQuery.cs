using Common.Query;
using Doctor.Query.UserAgg.DTOs;

namespace Doctor.Query.UserAgg.GetByPhoneNumber;

public record GetUserByPhoneNumberQuery(string PhoneNumber) : IQuery<UserDto?>;