
namespace Doctor.Domain.MedicalServicesAgg.Services;

public interface IMedicalServicesDomianService
{
    Task<List<MedicalService>?> GetList_MedicalService(CancellationToken cancellation);
    Task<MedicalService?> Get_MedicalService_By_Id(long medicalServiceid, CancellationToken cancellation);
}
