

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

    public async Task<DoctorInformation> Get_DoctorInfo_By_Id(long docInfoId)
    {
        return await _contex.DoctorInformations
               .FirstOrDefaultAsync(f => f.Id == docInfoId);
     
    }

    public async Task<List<DoctorInformation>> Get_List_DoctorInfo()
    {
        return await _contex.DoctorInformations.ToListAsync();
    }
}
