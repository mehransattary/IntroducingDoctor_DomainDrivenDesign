

using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Doctor.Application.AboutUsAgg.Create;

public record Create_AboutUs_Command(string Title,IFormFile ImageFile , string? Description) : IBaseCommand;
