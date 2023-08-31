

using Common.Domain.Repository;

namespace Doctor.Domain.VisitAgg.Repository;

public interface IVisitDayRepository:IBaseRepository<VisitDay>  
{
    Task<bool> DeleteVisitDay(long visitdayid);

}
