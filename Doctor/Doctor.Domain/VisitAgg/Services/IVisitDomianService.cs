

using Doctor.Domain.MedicalServicesAgg;

namespace Doctor.Domain.VisitAgg.Services;
public interface IVisitDomianService
{
    Task<List<VisitDay>?> GetList_VisitDay(CancellationToken cancellation);
    Task<VisitDay?> Get_VisitDay_By_Id(long visitDayId, CancellationToken cancellation);
}


