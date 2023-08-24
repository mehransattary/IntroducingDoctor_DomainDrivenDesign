

using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Doctor.Application.MedicalServiceAgg.Create;

public record Create_MedicalService_Command(string title, string shortDescription,IFormFile ImageFile) : IBaseCommand;
