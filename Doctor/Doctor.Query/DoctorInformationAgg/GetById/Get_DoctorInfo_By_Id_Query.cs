

using Common.Query;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Query.DoctorInformationAgg.DTOs;

namespace Doctor.Query.DoctorInformationAgg.GetById;

public record Get_DoctorInfo_By_Id_Query(long doctorInfoId): IQuery<DoctorInformationDto>;
