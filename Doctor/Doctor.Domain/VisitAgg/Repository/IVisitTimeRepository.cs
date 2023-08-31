

using Common.Domain.Repository;

namespace Doctor.Domain.VisitAgg.Repository;

public interface IVisitTimeRepository : IBaseRepository<VisitTime>
{
    Task<bool> DeleteVisitTime(long visitTimeid);

}
