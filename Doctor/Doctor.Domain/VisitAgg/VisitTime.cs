

using Common.Domain;
using Common.Domain.Exceptions;
using System.Reflection;

namespace Doctor.Domain.VisitAgg;

public class VisitTime : BaseEntity
{
    #region Constructor
    private VisitTime()
    {

    }
    public VisitTime(long visitDaysId,string startTime, string endTime)
    {
        NullOrEmptyDomainDataException.CheckString(startTime, nameof(startTime));
        NullOrEmptyDomainDataException.CheckString(endTime, nameof(endTime));

        this.StartTime = startTime;
        this.EndTime = endTime;
        this.VisitDayId = visitDaysId;  
    }
    #endregion

    #region Properties
    public long VisitDayId { get; internal set; }
    public string StartTime { get; private set; }
    public string EndTime { get; private set; }

    #endregion

    public void Edit(string startTime, string endTime)
    {
        NullOrEmptyDomainDataException.CheckString(startTime, nameof(startTime));
        NullOrEmptyDomainDataException.CheckString(endTime, nameof(endTime));

        this.StartTime = startTime;
        this.EndTime = endTime;
    }

}
