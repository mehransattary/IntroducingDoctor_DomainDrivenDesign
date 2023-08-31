
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
        if (request.FileImage == null)
            return OperationResult.Error();

        var imagename = await _fileService.SaveFileAndGenerateName(request.FileImage, Directories.DoctorInfoImages);

        var docInfo = new DoctorInformation(request.FullName, imagename, request.MedicalLicenseNumber,request.Email,request.Shortdesc,request.Desc);
       
        _repository.Add(docInfo);

        docInfo.SetSpecialization(request.Specializations) ;       

        await _repository.Save();

        return OperationResult.Success();   
    }
}
