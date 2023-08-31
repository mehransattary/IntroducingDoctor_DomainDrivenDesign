

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application._Utilities;
using Doctor.Domain.AboutUsAgg;
using Doctor.Domain.AboutUsAgg.Repository;
using Doctor.Domain.ContactUsAgg;
using Doctor.Domain.ContactUsAgg.Repository;
using Doctor.Domain.ContactUsAgg.Service;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;

namespace Doctor.Application.ContactUsAgg.Create;

public class Create_ContactUs_Command_Handler : IBaseCommandHandler<Create_ContactUs_Command>
{
    private readonly IContactUsRepository _repository;
    private readonly IContactUsDomainService _service;

    private readonly IFileService _fileService;

    public Create_ContactUs_Command_Handler(IContactUsRepository repository, IFileService fileService, IContactUsDomainService service)
    {
        _repository = repository;
        _fileService = fileService;
        _service = service;

    }
    public async Task<OperationResult> Handle(Create_ContactUs_Command request, CancellationToken cancellationToken)
    {
        if( await _service.IsExist_ContactUs())
            return OperationResult.Error("is exist aboutus in databasae");

        if (request.ImageFile == null)
            return OperationResult.Error();

        var imagename = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.AboutImages);

        var contactUs = new ContactUs(request.Title, imagename, request.Description);

        _repository.Add(contactUs);
        await _repository.Save();

        return OperationResult.Success();
    }
}
