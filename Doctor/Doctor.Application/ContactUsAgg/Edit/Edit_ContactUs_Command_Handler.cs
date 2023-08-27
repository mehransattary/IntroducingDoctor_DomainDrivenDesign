
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Doctor.Application._Utilities;
using Doctor.Domain.AboutUsAgg.Repository;
using Microsoft.AspNetCore.Http;

namespace Doctor.Application.ContactUsAgg.Edit;

public class Edit_ContactUs_Command_Handler : IBaseCommandHandler<Edit_ContactUs_Command>
{
    private readonly IAboutUsRepository _repository;
    private readonly IFileService _fileService;

    public Edit_ContactUs_Command_Handler(IAboutUsRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;

    }
    public async Task<OperationResult> Handle(Edit_ContactUs_Command request, CancellationToken cancellationToken)
    {
        var about = await _repository.GetTracking(request.Id);
        if (about == null)
            return OperationResult.NotFound();

        var imageName = about.ImageName;
        var oldImage = about.ImageName;

        if (request.ImageFile.IsImage())
            imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.AboutImages);

        about.Edit(request.Title, imageName, request.Description);
        DeleteOldImage(request.ImageFile, oldImage);

        await _repository.Save();
        return OperationResult.Success();
    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile.IsImage())
            _fileService.DeleteFile(Directories.DoctorInfoImages, oldImage);
    }
}
