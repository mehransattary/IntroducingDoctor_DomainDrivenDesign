

using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Doctor.Application.MedicalServiceAgg.Edit;

public record Edit_MedicalService_Command(long Id, string title, string shortDescription, IFormFile? ImageFile) : IBaseCommand<long>;
