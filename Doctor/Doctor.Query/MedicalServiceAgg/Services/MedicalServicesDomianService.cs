using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.MedicalServicesAgg.Services;
using Doctor.Infrastructure.Persistent.Ef.Persistent.Dapper;
using Doctor.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Application.MedicalServiceAgg.Services;

public class MedicalServicesDomianService : IMedicalServicesDomianService
{
    private readonly DapperContext _dapperContext;
    private readonly DoctorContext contex;

    public MedicalServicesDomianService(DoctorContext context, DapperContext dapperContext) 
    {
        _dapperContext = dapperContext;
        this.contex = context;
    }
    public async Task<List<MedicalService>?> GetList_MedicalService(CancellationToken cancellation)
    {
        return await contex.MedicalServices
               .ToListAsync(cancellation);
    }

    public async Task<MedicalService?> Get_MedicalService_By_Id(long medicalServiceid, CancellationToken cancellation)
    {
        return await contex.MedicalServices
                   .FirstOrDefaultAsync(f => f.Id == medicalServiceid, cancellation);

    }
}
