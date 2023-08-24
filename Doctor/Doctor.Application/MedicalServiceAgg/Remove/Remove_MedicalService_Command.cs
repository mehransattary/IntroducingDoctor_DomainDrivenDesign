

using Common.Application;

namespace Doctor.Application.MedicalServiceAgg.Remove;

public record Remove_MedicalService_Command(long medicalServiceId) : IBaseCommand;

