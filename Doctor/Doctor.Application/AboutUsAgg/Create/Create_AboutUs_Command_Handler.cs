

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application._Utilities;
using Doctor.Domain.AboutUsAgg;
using Doctor.Domain.AboutUsAgg.Repository;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;

namespace Doctor.Application.AboutUsAgg.Create;

public class Create_AboutUs_Command_Handler : IBaseCommandHandler<Create_AboutUs_Command>
{
    private readonly IAboutUsRepository _repository;
    private readonly IFileService _fileService;

    public Create_AboutUs_Command_Handler(IAboutUsRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;

    }
    public async Task<OperationResult> Handle(Create_AboutUs_Command request, CancellationToken cancellationToken)
    {
        if( await _repository.IsExist_AboutUs())
            return OperationResult.Error("is exist aboutus in databasae");

        if (request.ImageFile == null)
            return OperationResult.Error();

        var imagename = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.AboutImages);

        var about = new AboutUs(request.Title, imagename, request.Description);

        _repository.Add(about);
        await _repository.Save();

        return OperationResult.Success();
    }
}
