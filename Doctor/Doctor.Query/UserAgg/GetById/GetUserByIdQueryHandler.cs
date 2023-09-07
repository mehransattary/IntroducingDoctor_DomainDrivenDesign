using Common.Query;
using Doctor.Infrastructure.Persistent.Ef;
using Doctor.Query.UserAgg;
using Doctor.Query.UserAgg.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Query.UserAgg.GetById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
{
    private readonly DoctorContext _context;

    public GetUserByIdQueryHandler(DoctorContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);
        if (user == null)
            return null;


        return await user.Map().SetUserRoleTitles(_context);
    }
}