
using Common.Application;

using Microsoft.AspNetCore.Http;

namespace Doctor.Application.DoctorInformationAgg.Create;

public record Create_DoctorInfo_Command(string fullName, IFormFile fileImage, string medicalLicenseNumber, string email, string shortdesc, string desc):IBaseCommand;
