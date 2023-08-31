


using Doctor.Domain.AboutUsAgg;
using Doctor.Domain.AboutUsAgg.Services;
using Doctor.Infrastructure.Persistent.Ef.Persistent.Dapper;
using Doctor.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Application.AboutUsAgg.Service;

public class AboutDomainService : IAboutDomainService
{
    private readonly DapperContext _dapperContext;
    private readonly DoctorContext _contex;

    public AboutDomainService(DoctorContext context, DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
        _contex = context;
    }
    public async Task<AboutUs> Get_AboutUs()
    {
        var about = await _contex.AboutUs
          .FirstOrDefaultAsync();
        if (about == null)
            return new AboutUs("", "", "");
        return about;
    }


    public async Task<bool> IsExist_AboutUs()
    {
        return await _contex.AboutUs.AnyAsync();
    }
}
