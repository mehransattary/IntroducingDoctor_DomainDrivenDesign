using Common.Application.Validation;
using Doctor.Domain.RoleAgg;
using Doctor.Domain.RoleAgg.Repository;
using Doctor.Infrastructure._Utilities;

namespace Doctor.Infrastructure.Persistent.Ef.RoleAgg;

internal class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(DoctorContext context) : base(context)
    {
    }
}