
using Doctor.Domain.VisitAgg;
using Doctor.Domain.VisitAgg.Services;
using Doctor.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Doctor.Infrastructure.Persistent.Dapper;

namespace Doctor.Query.VisitAgg.Services;

public class VisitDomianService : IVisitDomianService
{
    private readonly DapperContext _dapperContext;
    private readonly DoctorContext _contex;

    public VisitDomianService(DoctorContext context, DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
        _contex = context;
    }
    public async Task<List<VisitDay>?> GetList_VisitDay(CancellationToken cancellation)
    {
        var res =await _contex.VisitDays.Include(x => x.VisitTimes).ToListAsync(cancellation);
        return res;

    }

    public async Task<VisitDay?> Get_VisitDay_By_Id(long visitDayId, CancellationToken cancellation)
    {
        var res = await _contex.VisitDays.Include(x => x.VisitTimes).Where(x=>x.Id==visitDayId).FirstOrDefaultAsync(cancellation);
        return res;
    }
}
