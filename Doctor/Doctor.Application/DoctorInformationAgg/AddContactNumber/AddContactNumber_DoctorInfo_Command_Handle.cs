
using Common.Application;
using Doctor.Domain.DoctorInformationAgg.Repository;

namespace Doctor.Application.DoctorInformationAgg.AddContactNumber;

public class AddContactNumber_DoctorInfo_Command_Handle : IBaseCommandHandler<AddContactNumber_DoctorInfo_Command>
{
    private readonly IDoctorInformationRepository _repository;

    public AddContactNumber_DoctorInfo_Command_Handle(IDoctorInformationRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(AddContactNumber_DoctorInfo_Command request, CancellationToken cancellationToken)
    {
        await _repository.AddContactNumber(request.DoctorInformationId,request.Mobile);

        return OperationResult.Success();
    }
}
