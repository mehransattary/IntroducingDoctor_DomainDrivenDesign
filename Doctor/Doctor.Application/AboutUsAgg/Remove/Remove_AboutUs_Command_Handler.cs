
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application._Utilities;
using Doctor.Domain.AboutUsAgg.Repository;

namespace Doctor.Application.AboutUsAgg.Remove;

public class Remove_AboutUs_Command_Handler : IBaseCommandHandler<Remove_AboutUs_Command>
{
    private readonly IAboutUsRepository _repository;
    private readonly IFileService _fileService;

    public Remove_AboutUs_Command_Handler(IAboutUsRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;

    }
    public async Task<OperationResult> Handle(Remove_AboutUs_Command request, CancellationToken cancellationToken)
    {
        var about = await _repository.GetTracking(request.Id);
        if (about == null)
            return OperationResult.NotFound();

        var res = await _repository.DeleteAboutUs(request.Id);
        if (res)
        {
            await _repository.Save();
            _fileService.DeleteFile(Directories.AboutImages, about.ImageName);
            return OperationResult.Success();
        }
        return OperationResult.Error("dont cant delete this about ");
    }
}
