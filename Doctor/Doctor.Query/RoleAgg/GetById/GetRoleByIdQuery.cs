using Common.Query;
using Doctor.Query.RoleAgg.DTOs;

namespace Doctor.Query.RoleAgg.GetById;

public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;