

using Common.Query;
using Doctor.Domain.VisitAgg;

namespace Doctor.Query.VisitAgg.DTOs;

public class VisitDayDto : BaseDto
{
    public string Title { get;  set; }
    public DayEnum Day { get;  set; }
    public List<VisitTime>? VisitTimes { get;  set; }
}

