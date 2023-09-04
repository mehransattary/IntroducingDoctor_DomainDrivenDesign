

using Common.Query;
using Doctor.Query.VisitAgg.DTOs;

namespace Doctor.Query.VisitAgg.GetByDayId;

public record Get_VisitDay_By_Id_Query(long visitDayId):IQuery<VisitDayDto>;

