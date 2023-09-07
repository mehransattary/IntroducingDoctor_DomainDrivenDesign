
using Doctor.Domain.ContactUsAgg;
using Doctor.Domain.ContactUsAgg.Repository;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Infrastructure._Utilities;
using Doctor.Infrastructure.Persistent.Dapper;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Infrastructure.Persistent.Ef.ContactUsAgg;

public class ContactUsRepository : BaseRepository<ContactUs>, IContactUsRepository
{
    private readonly DapperContext _dapperContext;
    private readonly DoctorContext _contex;

    public ContactUsRepository(DoctorContext context, DapperContext dapperContext) : base(context)
    {
        _dapperContext = dapperContext;
        _contex = context;
    }

    public async Task<bool> DeleteContactUs(long Id)
    {
        var about = await _contex.DoctorInformations
          .FirstOrDefaultAsync(f => f.Id == Id);
        if (about == null)
            return false;
        Context.RemoveRange(about);
        return true;
    }



}
