

using Common.Application;

namespace Doctor.Application.VisitAgg.EditTime;

public record EditTime_Command(long Id,long VisitDayId,string StartTime,string EndTime):IBaseCommand;

