using Common.Domain.Repository;
using Doctor.Domain.MedicalServicesAgg;


namespace Doctor.Domain.DoctorInformationAgg.Repository;

public interface IDoctorInformationRepository : IBaseRepository<DoctorInformation>
{
    Task<bool> DeleteDoctorInfo(long docInfoId);
    Task<long> AddAddress(long docInfoId, string textAddress, string? codePosti);
    Task<long> AddContactNumber(long docInfoId, string mobile);


}
