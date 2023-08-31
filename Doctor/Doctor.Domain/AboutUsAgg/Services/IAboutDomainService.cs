

namespace Doctor.Domain.AboutUsAgg.Services;

public interface IAboutDomainService
{
    Task<AboutUs> Get_AboutUs();

    Task<bool> IsExist_AboutUs();
}
