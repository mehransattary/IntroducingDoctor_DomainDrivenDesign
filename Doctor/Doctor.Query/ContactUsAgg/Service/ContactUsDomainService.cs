


using Doctor.Domain.ContactUsAgg;
using Doctor.Domain.ContactUsAgg.Service;
using Doctor.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Doctor.Infrastructure.Persistent.Dapper;

namespace Doctor.Query.ContactUsAgg.Service;

public class ContactUsDomainService : IContactUsDomainService
{
    private readonly DapperContext _dapperContext;
    private readonly DoctorContext _contex;

    public ContactUsDomainService(DoctorContext context, DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
        _contex = context;
    }
    public async Task<ContactUs> Get_ContactUs()
    {
        var about = await _contex.ContactUs
          .FirstOrDefaultAsync();
        if (about == null)
            return new ContactUs("", "", "");
        return about;
    }


    public async Task<bool> IsExist_ContactUs()
    {
        return await _contex.ContactUs.AnyAsync();
    }
}
