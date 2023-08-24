

using Common.Query;
using Doctor.Domain.MedicalServicesAgg;
using Doctor.Query.MedicalServiceAgg.DTOs;

namespace Doctor.Query.MedicalServiceAgg.GetList;

public record GetList_MedicalService_Query:IQuery<List<MedicalServiceDto>>;
