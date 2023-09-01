

using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Services;
using Doctor.Infrastructure.Persistent.Ef;
using Doctor.Infrastructure.Persistent.Ef.Persistent.Dapper;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Application.DoctorInformationAgg.Service;

public class DoctorInformationDomianService: IDoctorInformationDomianService
{
    private readonly DapperContext _dapperContext;
    private readonly DoctorContext _contex;

    public DoctorInformationDomianService(DoctorContext context, DapperContext dapperContext) 
    {
        _dapperContext = dapperContext;
        _contex = context;
    }
    public async Task<DoctorInformation?> Get_DoctorInfo_By_Id(long docInfoId)
    {
        return await _contex.DoctorInformations
               .FirstOrDefaultAsync(f => f.Id == docInfoId);

    }

    public async Task<List<DoctorInformation>> Get_List_DoctorInfo()
    {
        return await _contex.DoctorInformations.Include(x=>x.Addresses).Include(x=>x.ContactNumbers).ToListAsync();
    }
}
