


using Doctor.Domain.UserAgg;
using Doctor.Domain.UserAgg.Repository;
using Doctor.Infrastructure._Utilities;

namespace Doctor.Infrastructure.Persistent.Ef.UserAgg;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DoctorContext context) : base(context)
    {
    }
}