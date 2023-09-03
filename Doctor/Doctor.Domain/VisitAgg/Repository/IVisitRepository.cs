

using Common.Domain.Repository;
using MediatR;

namespace Doctor.Domain.VisitAgg.Repository;

public interface IVisitRepository:IBaseRepository<VisitDay>  
{
    Task<bool> DeleteVisitDay(long medicalServiceid);
    Task<bool> RemoveVisitTime(long visitDayId, long visitTimeId);
    Task<bool> EditVisitTime(long visitDayId, long visitTimeId);
    Task<bool> AddVisitTime(long visitDayId, string startTime, string endTime);

    
}
