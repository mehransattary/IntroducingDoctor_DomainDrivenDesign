

using Common.Query;
using Doctor.Query.MedicalServiceAgg.DTOs;

namespace Doctor.Query.MedicalServiceAgg.GetById;

public record Get_MedicalService_By_Id_Query(long medicalServiceId) : IQuery<MedicalServiceDto>;
