using Common.Query;
using Doctor.Infrastructure.Persistent.Ef;
using Doctor.Query.UserAgg;
using Doctor.Query.UserAgg.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Query.UserAgg.GetByPhoneNumber;

public class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
{
    private readonly DoctorContext _context;

    public GetUserByPhoneNumberQueryHandler(DoctorContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(f => f.PhoneNumber == request.PhoneNumber, cancellationToken);

        if (user == null)
            return null;


        return await user.Map().SetUserRoleTitles(_context);
    }
}