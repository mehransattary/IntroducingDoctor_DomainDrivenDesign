

using Common.Application;

namespace Doctor.Application.VisitAgg.AddTime;

public record AddTime_Command(long VisitDayId,string StartTime,string EndTime):IBaseCommand;


