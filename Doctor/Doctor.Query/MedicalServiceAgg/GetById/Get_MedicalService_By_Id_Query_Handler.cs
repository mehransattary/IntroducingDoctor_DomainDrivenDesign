

using Common.Query;
using Doctor.Domain.MedicalServicesAgg.Repository;
using Doctor.Domain.MedicalServicesAgg.Services;
using Doctor.Infrastructure.Persistent.Ef;
using Doctor.Query.MedicalServiceAgg.DTOs;
using Doctor.Query.MedicalServiceAgg.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Query.MedicalServiceAgg.GetById;

public class Get_MedicalService_By_Id_Query_Handler : IQueryHandler<Get_MedicalService_By_Id_Query, MedicalServiceDto>
{
    private readonly IMedicalServicesDomianService _medicalServicesDomianService;
    public Get_MedicalService_By_Id_Query_Handler(IMedicalServicesDomianService medicalServicesDomianService)
    {
        _medicalServicesDomianService = medicalServicesDomianService;
    }
    public async Task<MedicalServiceDto> Handle(Get_MedicalService_By_Id_Query request, CancellationToken cancellationToken)
    {
        var model = await _medicalServicesDomianService.Get_MedicalService_By_Id(request.medicalServiceId, cancellationToken);
        return model.Map();
    }
}
