
using Common.Application;

using Microsoft.AspNetCore.Http;

namespace Doctor.Application.DoctorInformationAgg.Remove;

public record Remove_DoctorInfo_Command(long docInfoId):IBaseCommand;
