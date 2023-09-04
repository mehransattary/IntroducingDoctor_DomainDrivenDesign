

using Common.Query;
using Doctor.Domain.DoctorInformationAgg.Services;
using Doctor.Domain.VisitAgg.Services;
using Doctor.Query.VisitAgg.DTOs;
using Doctor.Query.VisitAgg.Mapper;

namespace Doctor.Query.VisitAgg.GetByDayId;

public class Get_VisitDay_By_Id_Query_Handler : IQueryHandler<Get_VisitDay_By_Id_Query, VisitDayDto>
{
    private readonly IVisitDomianService _visitDayService;
    public Get_VisitDay_By_Id_Query_Handler(IVisitDomianService visitDayService)
    {
        _visitDayService = visitDayService;
    }
    public async Task<VisitDayDto> Handle(Get_VisitDay_By_Id_Query request, CancellationToken cancellationToken)
    {
        var visitDay =await _visitDayService.Get_VisitDay_By_Id(request.visitDayId, cancellationToken);
        return visitDay.Map();

    }
}
