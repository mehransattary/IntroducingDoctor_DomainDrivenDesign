using Common.Application;
using Doctor.Domain.RoleAgg.Enums;

namespace Doctor.Application.RoleAgg.Edit;

public record EditRoleCommand(long Id, string Title, List<Permission> Permissions) : IBaseCommand;