using Common.Query;
using Doctor.Infrastructure.Persistent.Ef;
using Doctor.Query.RoleAgg.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Query.RoleAgg.GetList;

public class GetRoleListQueryHandler : IQueryHandler<GetRoleListQuery, List<RoleDto>>
{
    private readonly DoctorContext _context;

    public GetRoleListQueryHandler(DoctorContext context)
    {
        _context = context;
    }
    public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Roles.Select(role => new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Permissions = role.Permissions.Select(s => s.Permission).ToList(),
            Title = role.Title
        }).ToListAsync(cancellationToken);
    }
}