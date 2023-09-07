using Common.Query;
using Doctor.Query.UserAgg.DTOs;

namespace Doctor.Query.UserAgg.GetByFilter;

public class GetUserByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
{
    public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
    {
    }
}