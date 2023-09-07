using Common.Query;
using Doctor.Query.UserAgg.DTOs;

namespace Doctor.Query.UserAgg.GetById;

public class GetUserByIdQuery : IQuery<UserDto?>
{
    public GetUserByIdQuery(long userId)
    {
        UserId = userId;
    }

    public long UserId { get; private set; }
}