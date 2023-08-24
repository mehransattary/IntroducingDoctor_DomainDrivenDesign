
using Common.Application;

using Microsoft.AspNetCore.Http;

namespace Doctor.Application.DoctorInformationAgg.Edit;

public record Edit_DoctorInfo_Command(long Id,string fullName, IFormFile? fileImage, string medicalLicenseNumber, string email, string shortdesc, string desc):IBaseCommand;
