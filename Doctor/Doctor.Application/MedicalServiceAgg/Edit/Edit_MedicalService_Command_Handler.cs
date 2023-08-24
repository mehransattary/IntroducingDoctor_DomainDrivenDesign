

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Doctor.Application._Utilities;
using Doctor.Domain.MedicalServicesAgg.Repository;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Doctor.Application.MedicalServiceAgg.Edit;

public class Edit_MedicalService_Command_Handler : IBaseCommandHandler<Edit_MedicalService_Command, long>
{
    private readonly IMedicalServiceRepository _repository;
    private readonly IFileService _fileService;

    public Edit_MedicalService_Command_Handler(IMedicalServiceRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;

    }
    public async Task<OperationResult<long>> Handle(Edit_MedicalService_Command request, CancellationToken cancellationToken)
    {
        var medicalService = await _repository.GetTracking(request.Id);
        if (medicalService == null)
            return OperationResult<long>.NotFound();
        var imageName = medicalService.Image;
        var oldImage = medicalService.Image;
        if (request.ImageFile.IsImage())    
            imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.MedicalServiceImages);
           

        medicalService.Edit(request.title, request.shortDescription, imageName);
        DeleteOldImage(request.ImageFile, oldImage);

        await _repository.Save();
        return OperationResult<long>.Success(request.Id);
    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile.IsImage())
            _fileService.DeleteFile(Directories.MedicalServiceImages, oldImage);
    }
}
