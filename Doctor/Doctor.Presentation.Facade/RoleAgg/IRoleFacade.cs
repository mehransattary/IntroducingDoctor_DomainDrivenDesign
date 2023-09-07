using Common.Application;
using Doctor.Application.RoleAgg.Create;
using Doctor.Application.RoleAgg.Edit;
using Doctor.Query.RoleAgg.DTOs;

namespace Doctor.Presentation.Facade.RoleAgg;

public interface IRoleFacade
{
    Task<OperationResult> CreateRole(CreateRoleCommand command);
    Task<OperationResult> EditRole(EditRoleCommand command);

    Task<RoleDto?> GetRoleById(long roleId);
    Task<List<RoleDto>> GetRoles();
}