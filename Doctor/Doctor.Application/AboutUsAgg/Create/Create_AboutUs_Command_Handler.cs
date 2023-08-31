

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application._Utilities;
using Doctor.Domain.AboutUsAgg;
using Doctor.Domain.AboutUsAgg.Repository;
using Doctor.Domain.AboutUsAgg.Services;


namespace Doctor.Application.AboutUsAgg.Create;

public class Create_AboutUs_Command_Handler : IBaseCommandHandler<Create_AboutUs_Command>
{
    private readonly IAboutDomainService _AboutUsService;
    private readonly IAboutUsRepository _AboutUsRepository;

    private readonly IFileService _fileService;

    public Create_AboutUs_Command_Handler(IAboutDomainService AboutUsService, IFileService fileService, IAboutUsRepository AboutUsRepository)
    {
        _AboutUsService = AboutUsService;
        _AboutUsRepository = AboutUsRepository;
        _fileService = fileService;

    }
    public async Task<OperationResult> Handle(Create_AboutUs_Command request, CancellationToken cancellationToken)
    {
        if( await _AboutUsService.IsExist_AboutUs())
            return OperationResult.Error("is exist aboutus in databasae");

        if (request.ImageFile == null)
            return OperationResult.Error();

        var imagename = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.AboutImages);

        var about = new AboutUs(request.Title, imagename, request.Description);

        _AboutUsRepository.Add(about);
        await _AboutUsRepository.Save();

        return OperationResult.Success();
    }
}
