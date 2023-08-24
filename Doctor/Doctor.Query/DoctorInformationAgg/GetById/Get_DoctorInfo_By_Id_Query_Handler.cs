

using Common.Query;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Query.DoctorInformationAgg.DTOs;
using Doctor.Query.DoctorInformationAgg.Mapper;

namespace Doctor.Query.DoctorInformationAgg.GetById;

public class Get_DoctorInfo_By_Id_Query_Handler : IQueryHandler<Get_DoctorInfo_By_Id_Query, DoctorInformationDto>
{
    private readonly IDoctorInformationRepository _doctorInfoRepository;
    public Get_DoctorInfo_By_Id_Query_Handler(IDoctorInformationRepository doctorInfoRepository)
    {
        _doctorInfoRepository = doctorInfoRepository;
    }
    public async Task<DoctorInformationDto> Handle(Get_DoctorInfo_By_Id_Query request, CancellationToken cancellationToken)
    {
        var docInfo =await _doctorInfoRepository.Get_DoctorInfo_By_Id(request.doctorInfoId);
        return docInfo.Map();
    }
}
