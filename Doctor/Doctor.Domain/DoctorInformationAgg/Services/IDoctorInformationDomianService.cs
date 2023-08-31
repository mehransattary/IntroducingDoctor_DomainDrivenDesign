

namespace Doctor.Domain.DoctorInformationAgg.Services;

public interface IDoctorInformationDomianService
{
    Task<DoctorInformation> Get_DoctorInfo_By_Id(long docInfoId);
    Task<List<DoctorInformation>> Get_List_DoctorInfo();
}
