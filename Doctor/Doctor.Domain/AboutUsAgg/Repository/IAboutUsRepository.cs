

using Common.Domain.Repository;
using Doctor.Domain.DoctorInformationAgg;

namespace Doctor.Domain.AboutUsAgg.Repository;

public interface IAboutUsRepository : IBaseRepository<AboutUs>
{
    Task<bool> DeleteAboutUs(long Id);

}
