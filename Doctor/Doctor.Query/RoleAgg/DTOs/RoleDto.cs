using Common.Query;
using Doctor.Domain.RoleAgg.Enums;

namespace Doctor.Query.RoleAgg.DTOs;

public class RoleDto : BaseDto
{
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}