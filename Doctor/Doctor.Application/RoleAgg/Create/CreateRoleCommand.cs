using Common.Application;
using Doctor.Domain.RoleAgg.Enums;

namespace Doctor.Application.RoleAgg.Create;

public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;