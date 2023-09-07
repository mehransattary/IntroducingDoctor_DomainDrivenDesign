using Common.Domain;
using Doctor.Domain.RoleAgg.Enums;

namespace Doctor.Domain.RoleAgg;

public class RolePermission : BaseEntity
{
    public RolePermission(Permission permission)
    {
        Permission = permission;
    }

    public long RoleId { get; internal set; }
    public Permission Permission { get; private set; }
}
