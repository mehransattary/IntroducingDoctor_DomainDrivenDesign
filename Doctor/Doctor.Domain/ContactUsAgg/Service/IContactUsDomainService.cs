
namespace Doctor.Domain.ContactUsAgg.Service;

public interface IContactUsDomainService
{
    Task<ContactUs> Get_ContactUs();
     Task<bool> IsExist_ContactUs();
}
