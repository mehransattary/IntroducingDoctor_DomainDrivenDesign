

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
    public VisitTime(string startTime, string endTime)
    {
        NullOrEmptyDomainDataException.CheckString(startTime, nameof(startTime));
        NullOrEmptyDomainDataException.CheckString(endTime, nameof(endTime));

        this.StartTime = startTime;
        this.EndTime = endTime;
    }
    #endregion

    #region Properties
  
    public string StartTime { get; private set; }
    public string EndTime { get; private set; }

    public long VisitDaysId { get; internal set; }

    #endregion



}
