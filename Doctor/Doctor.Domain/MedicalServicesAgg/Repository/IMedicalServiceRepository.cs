

using Common.Domain.Repository;

namespace Doctor.Domain.MedicalServicesAgg.Repository;

public interface IMedicalServiceRepository : IBaseRepository<MedicalService>
{
    Task<bool> DeleteMedicalService(long medicalServiceid);
    Task<MedicalService?> Get_MedicalService_By_Id(long medicalServiceid, CancellationToken cancellation);
    Task<List<MedicalService>?> GetList_MedicalService(CancellationToken cancellation);

}
