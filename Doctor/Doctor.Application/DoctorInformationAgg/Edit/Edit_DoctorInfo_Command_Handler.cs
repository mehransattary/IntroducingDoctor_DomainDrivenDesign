
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Doctor.Application._Utilities;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.MedicalServicesAgg;
using Microsoft.AspNetCore.Http;

namespace Doctor.Application.DoctorInformationAgg.Edit;

public class Edit_DoctorInfo_Command_Handler : IBaseCommandHandler<Edit_DoctorInfo_Command>
{
    private readonly IDoctorInformationRepository _repository;
    private readonly IFileService _fileService;

    public Edit_DoctorInfo_Command_Handler(IDoctorInformationRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;

    }

    public async Task<OperationResult> Handle(Edit_DoctorInfo_Command request, CancellationToken cancellationToken)
    {
        var docInfo = await _repository.GetTracking(request.Id);
        if (docInfo == null)
            return OperationResult.NotFound();

        var imageName = docInfo.ImageName;
        var oldImage = docInfo.ImageName;

        if (request.fileImage.IsImage())
            imageName = await _fileService.SaveFileAndGenerateName(request.fileImage, Directories.DoctorInfoImages);

        docInfo.Edit(request.fullName,imageName, request.medicalLicenseNumber,request.email, request.shortdesc,request.desc);
        DeleteOldImage(request.fileImage, oldImage);

        await _repository.Save();
        return OperationResult.Success();
    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile.IsImage())
            _fileService.DeleteFile(Directories.DoctorInfoImages, oldImage);
    }
}
