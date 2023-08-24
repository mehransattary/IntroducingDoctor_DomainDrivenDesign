
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application._Utilities;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.MedicalServicesAgg;

namespace Doctor.Application.DoctorInformationAgg.Create;

public class Create_DoctorInfo_Command_Handler : IBaseCommandHandler<Create_DoctorInfo_Command>
{
    private readonly IDoctorInformationRepository _repository;
    private readonly IFileService _fileService;

    public Create_DoctorInfo_Command_Handler(IDoctorInformationRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;

    }

    public async Task<OperationResult> Handle(Create_DoctorInfo_Command request, CancellationToken cancellationToken)
    {
        if (request.fileImage == null)
            return OperationResult.Error();

        var imagename = await _fileService.SaveFileAndGenerateName(request.fileImage, Directories.DoctorInfoImages);

        var docInfo = new DoctorInformation(request.fullName, imagename, request.medicalLicenseNumber,request.email,request.shortdesc,request.desc);

        _repository.Add(docInfo);
        await _repository.Save();

        return OperationResult.Success();   
    }
}
