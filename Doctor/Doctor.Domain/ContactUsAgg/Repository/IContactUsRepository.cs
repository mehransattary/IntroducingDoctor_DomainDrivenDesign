

using Common.Domain.Repository;
using Doctor.Domain.AboutUsAgg;

namespace Doctor.Domain.ContactUsAgg.Repository;

public interface IContactUsRepository : IBaseRepository<ContactUs>
{
    Task<bool> DeleteContactUs(long Id);
    Task<ContactUs> Get_ContactUs();
    Task<bool> IsExist_ContactUs();
}
