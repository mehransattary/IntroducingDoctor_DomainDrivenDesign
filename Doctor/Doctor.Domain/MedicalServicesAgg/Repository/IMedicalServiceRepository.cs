

using Common.Domain.Repository;

namespace Doctor.Domain.MedicalServicesAgg.Repository;

public interface IMedicalServiceRepository : IBaseRepository<MedicalService>
{
    Task<bool> DeleteMedicalService(long medicalServiceid);


}
