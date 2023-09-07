using Common.Application;
using Doctor.Domain.RoleAgg;
using Doctor.Domain.RoleAgg.Repository;

namespace Doctor.Application.RoleAgg.Create;

public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _repository;

    public CreateRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var permissions = new List<RolePermission>();
        request.Permissions.ForEach(f =>
        {
            permissions.Add(new RolePermission(f));
        });
        var role = new Role(request.Title, permissions);
        _repository.Add(role);
        await _repository.Save();

        return OperationResult.Success();
    }
}