
using Common.Application;
using Doctor.Domain.DoctorInformationAgg;
using Microsoft.AspNetCore.Http;

namespace Doctor.Application.DoctorInformationAgg.Create;

public record Create_DoctorInfo_Command(string FullName, IFormFile FileImage, string? MedicalLicenseNumber, string? Email, string? Shortdesc, string? Desc,List<Specialization> Specializations):IBaseCommand;
