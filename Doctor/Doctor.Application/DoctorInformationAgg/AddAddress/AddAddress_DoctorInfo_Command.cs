
using Common.Application;

namespace Doctor.Application.DoctorInformationAgg.AddAddress;

public record AddAddress_DoctorInfo_Command(long DoctorInformationId, string TextAddress, string? CodePosti) :IBaseCommand;

