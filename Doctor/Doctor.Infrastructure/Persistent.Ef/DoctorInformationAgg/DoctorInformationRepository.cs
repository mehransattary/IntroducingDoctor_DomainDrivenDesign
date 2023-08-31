

using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.MedicalServicesAgg;
using Doctor.Infrastructure._Utilities;
using Doctor.Infrastructure.Persistent.Ef.Persistent.Dapper;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Infrastructure.Persistent.Ef.Doctor_Information;

public class DoctorInformationRepository : BaseRepository<DoctorInformation>, IDoctorInformationRepository
{
    private readonly DapperContext _dapperContext;
    private readonly DoctorContext _contex;

    public DoctorInformationRepository(DoctorContext context, DapperContext dapperContext) : base(context)
    {
        _dapperContext = dapperContext;
        _contex = context;
    }
    public async Task<bool> DeleteDoctorInfo(long docInfoId)
    {
        var docInfo = await _contex.DoctorInformations
          .FirstOrDefaultAsync(f => f.Id == docInfoId);
        if (docInfo == null)
            return false;
        Context.RemoveRange(docInfo);
        return true;
    }
    public async Task<long> AddAddress(long docInfoId, string textAddress, string? codePosti)
    {
        var addresse = new Address(textAddress, codePosti);

        var docInfo = await _contex.DoctorInformations
         .FirstOrDefaultAsync(f => f.Id == docInfoId);
        if (docInfo == null)
            return 0;
        docInfo.SetAddress(addresse);
       await Context.SaveChangesAsync();
        return docInfo.Id;
    }
    public async Task<long> AddContactNumber(long docInfoId, string mobile)
    {
        var contract = new ContactNumber(mobile);

        var docInfo = await _contex.DoctorInformations
         .FirstOrDefaultAsync(f => f.Id == docInfoId);
        if (docInfo == null)
            return 0;
        docInfo.SetContactNumber(contract);
        await Context.SaveChangesAsync();
        return docInfo.Id;
    }


}
