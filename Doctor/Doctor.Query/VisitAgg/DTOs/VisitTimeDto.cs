

using Common.Query;

namespace Doctor.Query.VisitAgg.DTOs;

public class VisitTimeDto : BaseDto
{
    public string StartTime { get;  set; }
    public string EndTime { get;  set; }
    public long VisitDaysId { get;  set; }
}

