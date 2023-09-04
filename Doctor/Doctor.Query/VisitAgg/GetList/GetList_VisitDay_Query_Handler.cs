

using Common.Query;
using Doctor.Domain.VisitAgg.Services;
using Doctor.Query.VisitAgg.DTOs;
using Doctor.Query.VisitAgg.Mapper;

namespace Doctor.Query.VisitAgg.GetList;

public class GetList_VisitDay_Query_Handler : IQueryHandler<GetList_VisitDay_Query, List<VisitDayDto>>
{
    private readonly IVisitDomianService _visitDayService;
    public GetList_VisitDay_Query_Handler(IVisitDomianService visitDayService)
    {
        _visitDayService = visitDayService;
    }
    public  async Task<List<VisitDayDto>> Handle(GetList_VisitDay_Query request, CancellationToken cancellationToken)
    {
        var visitDay = await _visitDayService.GetList_VisitDay( cancellationToken);
        return visitDay.Map();
    }
}
