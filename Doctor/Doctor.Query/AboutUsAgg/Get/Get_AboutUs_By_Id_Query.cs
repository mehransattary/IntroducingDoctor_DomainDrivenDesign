

using Common.Query;
using Doctor.Domain.AboutUsAgg;
using Doctor.Query.AboutUsAgg.DTOs;
using Doctor.Query.DoctorInformationAgg.GetById;

namespace Doctor.Query.AboutUsAgg.GetById;

public record Get_AboutUs_Query:IQuery<AboutUsDto>;
