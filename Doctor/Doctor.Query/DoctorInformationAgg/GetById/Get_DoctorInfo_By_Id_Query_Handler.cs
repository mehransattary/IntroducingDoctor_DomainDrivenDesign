

using Common.Query;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.DoctorInformationAgg.Services;
using Doctor.Query.DoctorInformationAgg.DTOs;
using Doctor.Query.DoctorInformationAgg.Mapper;

namespace Doctor.Query.DoctorInformationAgg.GetById;

public class Get_DoctorInfo_By_Id_Query_Handler : IQueryHandler<Get_DoctorInfo_By_Id_Query, DoctorInformationDto>
{
    private readonly IDoctorInformationDomianService _doctorInfoService;
    public Get_DoctorInfo_By_Id_Query_Handler(IDoctorInformationDomianService doctorInfoService)
    {
        _doctorInfoService = doctorInfoService;
    }
    public async Task<DoctorInformationDto> Handle(Get_DoctorInfo_By_Id_Query request, CancellationToken cancellationToken)
    {
        var docInfo =await _doctorInfoService.Get_DoctorInfo_By_Id(request.doctorInfoId);
        return docInfo.Map();
    }
}
