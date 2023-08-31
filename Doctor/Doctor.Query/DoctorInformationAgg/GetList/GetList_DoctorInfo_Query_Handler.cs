
using Common.Query;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.DoctorInformationAgg.Services;
using Doctor.Query.DoctorInformationAgg.DTOs;
using Doctor.Query.DoctorInformationAgg.Mapper;

namespace Doctor.Query.DoctorInformationAgg.GetList;

public class GetList_DoctorInfo_Query_Handler : IQueryHandler<GetList_DoctorInfo_Query, List<DoctorInformationDto>>
{
    private readonly IDoctorInformationDomianService _doctorInfoService;
    public GetList_DoctorInfo_Query_Handler(IDoctorInformationDomianService doctorInfoService)
    {
        _doctorInfoService = doctorInfoService;
    }
    public async Task<List<DoctorInformationDto>> Handle(GetList_DoctorInfo_Query request, CancellationToken cancellationToken)
    {
        var res =await _doctorInfoService.Get_List_DoctorInfo();
        return res.Map();

    }
}

