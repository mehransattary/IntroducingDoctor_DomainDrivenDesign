
using Doctor.Domain.AboutUsAgg;
using Doctor.Domain.AboutUsAgg.Repository;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Infrastructure._Utilities;
using Doctor.Infrastructure.Persistent.Ef.Persistent.Dapper;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Infrastructure.Persistent.Ef.AboutUsAgg;

public class AboutUsRepository : BaseRepository<AboutUs>, IAboutUsRepository
{
    private readonly DapperContext _dapperContext;
    private readonly DoctorContext _contex;

    public AboutUsRepository(DoctorContext context, DapperContext dapperContext) : base(context)
    {
        _dapperContext = dapperContext;
        _contex = context;
    }

    public async Task<bool> DeleteAboutUs(long Id)
    {
        var about = await _contex.DoctorInformations
          .FirstOrDefaultAsync(f => f.Id == Id);
        if (about == null)
            return false;
        Context.RemoveRange(about);
        return true;
    }

    public async Task<AboutUs> Get_AboutUs()
    {
        var about = await _contex.AboutUs
          .FirstOrDefaultAsync();
        if (about == null)
            return new AboutUs("","","");
        return about;
    }


    public async Task<bool> IsExist_AboutUs()
    {
        return await _contex.AboutUs.AnyAsync();
    }

}
