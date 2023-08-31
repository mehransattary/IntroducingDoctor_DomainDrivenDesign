

using Common.Query;
using Doctor.Domain.MedicalServicesAgg.Repository;
using Doctor.Domain.MedicalServicesAgg.Services;
using Doctor.Infrastructure.Persistent.Ef;
using Doctor.Query.MedicalServiceAgg.DTOs;
using Doctor.Query.MedicalServiceAgg.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Query.MedicalServiceAgg.GetList;

public class GetList_MedicalService_Query_Handler : IQueryHandler<GetList_MedicalService_Query, List<MedicalServiceDto>>
{
    private readonly IMedicalServicesDomianService _medicalServicesDomianService;
    public GetList_MedicalService_Query_Handler(IMedicalServicesDomianService medicalServicesDomianService)
    {
        _medicalServicesDomianService = medicalServicesDomianService;
    }
    public async Task<List<MedicalServiceDto>> Handle(GetList_MedicalService_Query request, CancellationToken cancellationToken)
    {
        var res =await _medicalServicesDomianService.GetList_MedicalService(cancellationToken);
        return res.Map();
    }
}
