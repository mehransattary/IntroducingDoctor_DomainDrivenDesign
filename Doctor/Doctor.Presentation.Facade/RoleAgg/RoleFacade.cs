using Common.Application;
using Doctor.Application.RoleAgg.Create;
using Doctor.Application.RoleAgg.Edit;
using Doctor.Query.RoleAgg.DTOs;
using Doctor.Query.RoleAgg.GetById;
using Doctor.Query.RoleAgg.GetList;
using MediatR;


namespace Doctor.Presentation.Facade.RoleAgg;

internal class RoleFacade : IRoleFacade
{
    private readonly IMediator _mediator;

    public RoleFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> CreateRole(CreateRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> EditRole(EditRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<RoleDto?> GetRoleById(long roleId)
    {
        return await _mediator.Send(new GetRoleByIdQuery(roleId));
    }
    public async Task<List<RoleDto>> GetRoles()
    {
        return await _mediator.Send(new GetRoleListQuery());
    }
}