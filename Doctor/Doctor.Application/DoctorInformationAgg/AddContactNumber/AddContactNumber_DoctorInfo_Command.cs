
using Common.Application;

namespace Doctor.Application.DoctorInformationAgg.AddContactNumber;

public record AddContactNumber_DoctorInfo_Command(long DoctorInformationId, string Mobile) :IBaseCommand;

