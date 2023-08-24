

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application._Utilities;
using Doctor.Domain.MedicalServicesAgg.Repository;

namespace Doctor.Application.MedicalServiceAgg.Remove;

public class Remove_MedicalService_Command_Handle : IBaseCommandHandler<Remove_MedicalService_Command>
{
    private readonly IMedicalServiceRepository _repository;
    private readonly IFileService _fileService;

    public Remove_MedicalService_Command_Handle(IMedicalServiceRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;

    }
    public async Task<OperationResult> Handle(Remove_MedicalService_Command request, CancellationToken cancellationToken)
    {
        var medicalService = await _repository.GetTracking(request.medicalServiceId);
        if (medicalService == null)
            return OperationResult.NotFound();

        var res = await _repository.DeleteMedicalService(request.medicalServiceId);
        if (res)
        {
            await _repository.Save();
            _fileService.DeleteFile(Directories.MedicalServiceImages, medicalService.Image);
            return OperationResult.Success();
        }
        return OperationResult.Error("dont cant delete this medical service");
    }
}

