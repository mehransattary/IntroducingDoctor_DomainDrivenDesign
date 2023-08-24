

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application._Utilities;
using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.MedicalServicesAgg.Repository;

namespace Doctor.Application.MedicalServiceAgg.Create;

public class Create_MedicalService_Command_Handler : IBaseCommandHandler<Create_MedicalService_Command>
{
    private readonly IMedicalServiceRepository _repository;
    private readonly IFileService _fileService;

    public Create_MedicalService_Command_Handler(IMedicalServiceRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;

    }
    public async Task<OperationResult> Handle(Create_MedicalService_Command request, CancellationToken cancellationToken)
    {
         if(request.ImageFile==null)
            return OperationResult.Error();

        var imagename = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.MedicalServiceImages);
   
        var medicalService = new MedicalService(request.title, request.shortDescription, imagename);
        _repository.Add(medicalService);

        await _repository.Save();
        return OperationResult.Success();
    }
}
