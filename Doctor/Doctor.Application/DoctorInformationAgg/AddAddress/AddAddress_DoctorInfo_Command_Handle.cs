
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Domain.DoctorInformationAgg.Repository;

namespace Doctor.Application.DoctorInformationAgg.AddAddress;

public class AddAddress_DoctorInfo_Command_Handle : IBaseCommandHandler<AddAddress_DoctorInfo_Command>
{
    private readonly IDoctorInformationRepository _repository;

    public AddAddress_DoctorInfo_Command_Handle(IDoctorInformationRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AddAddress_DoctorInfo_Command request, CancellationToken cancellationToken)
    {

        await _repository.AddAddress(request.DoctorInformationId, request.TextAddress, request.CodePosti);

        return OperationResult.Success();
    }
}

