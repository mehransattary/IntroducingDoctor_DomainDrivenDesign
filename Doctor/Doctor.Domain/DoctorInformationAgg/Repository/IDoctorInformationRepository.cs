using Common.Domain.Repository;
using Doctor.Domain.MedicalServicesAgg;


namespace Doctor.Domain.DoctorInformationAgg.Repository;

public interface IDoctorInformationRepository : IBaseRepository<DoctorInformation>
{
    Task<bool> DeleteDoctorInfo(long docInfoId);
    Task<DoctorInformation> Get_DoctorInfo_By_Id(long docInfoId);
    Task<List<DoctorInformation>> Get_List_DoctorInfo();

}
