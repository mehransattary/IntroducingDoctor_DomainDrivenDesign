using Common.Query;
using Doctor.Infrastructure.Persistent.Ef;
using Doctor.Query.RoleAgg.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Query.RoleAgg.GetById;

public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto?>
{
    private readonly DoctorContext _context;

    public GetRoleByIdQueryHandler(DoctorContext context)
    {
        _context = context;
    }

    public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(f => f.Id == request.RoleId, cancellationToken: cancellationToken);
        if (role == null)
            return null;

        return new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Permissions = role.Permissions.Select(s => s.Permission).ToList(),
            Title = role.Title
        };
    }
}