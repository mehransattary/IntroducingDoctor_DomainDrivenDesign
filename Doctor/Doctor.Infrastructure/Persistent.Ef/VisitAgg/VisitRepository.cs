

using Doctor.Domain.VisitAgg;
using Doctor.Domain.VisitAgg.Repository;
using Doctor.Infrastructure._Utilities;

namespace Doctor.Infrastructure.Persistent.Ef.VisitAgg;

public class VisitRepository : BaseRepository<VisitDay>, IVisitRepository
{
   
    private readonly DoctorContext _context;
    public VisitRepository(DoctorContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> AddVisitTime(long visitDayId, string startTime, string endTime)
    {
        var visitDay = await GetTracking(visitDayId);
        if (visitDay == null)
            return false;
        visitDay.AddTime(new VisitTime(startTime, endTime));
        await Save();
        return true;
    }

    public Task<bool> DeleteVisitDay(long medicalServiceid)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> EditVisitTime(long visitDayId, long visitTimeId,string startTime,string endTime)
    {
        var visitDay = await GetTracking(visitDayId);
        if (visitDay == null)
            return false;

        var visitTime = visitDay.VisitTimes.FirstOrDefault(x => x.VisitDaysId == visitDay.Id);
        if (visitTime == null)
            return false;

        visitTime.Edit(startTime, endTime);
        await Save();
        return true;
    }

    public Task<bool> EditVisitTime(long visitDayId, long visitTimeId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveVisitTime(long visitDayId,long visitTimeId)
    {
        var visitDay =await GetTracking(visitDayId);
        if (visitDay == null)
            return false;

        var visitTime=  visitDay.VisitTimes.FirstOrDefault(x=>x.VisitDaysId==visitDay.Id);
        if(visitTime==null)
            return false;

        visitDay.RemoveTime(visitTime);
        await Save();
        return true;
    }
}
