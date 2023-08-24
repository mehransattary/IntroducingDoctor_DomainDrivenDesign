
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Doctor.Application._Utilities;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.MedicalServicesAgg;
using Microsoft.AspNetCore.Http;

namespace Doctor.Application.DoctorInformationAgg.Remove;

public class Remove_DoctorInfo_Command_Handler : IBaseCommandHandler<Remove_DoctorInfo_Command>
{
    private readonly IDoctorInformationRepository _repository;
    private readonly IFileService _fileService;

    public Remove_DoctorInfo_Command_Handler(IDoctorInformationRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;

    }

    public async Task<OperationResult> Handle(Remove_DoctorInfo_Command request, CancellationToken cancellationToken)
    {
        var docInfo = await _repository.GetTracking(request.docInfoId);
        if (docInfo == null)
            return OperationResult.NotFound();

        var res = await _repository.DeleteDoctorInfo(request.docInfoId);
        if (res)
        {
            await _repository.Save();
            _fileService.DeleteFile(Directories.DoctorInfoImages, docInfo.ImageName);
            return OperationResult.Success();
        }
        return OperationResult.Error("dont cant delete this doctor Info");
    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile.IsImage())
            _fileService.DeleteFile(Directories.DoctorInfoImages, oldImage);
    }
}
