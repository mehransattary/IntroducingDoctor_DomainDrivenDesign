

using Common.Query;
using Doctor.Domain.AboutUsAgg;
using Doctor.Query.AboutUsAgg.DTOs;
using Doctor.Query.ContactUsAgg.DTOs;
using Doctor.Query.DoctorInformationAgg.GetById;

namespace Doctor.Query.ContactUsAgg.GetById;

public record Get_ContactUs_Query : IQuery<ContactUsDto>;
