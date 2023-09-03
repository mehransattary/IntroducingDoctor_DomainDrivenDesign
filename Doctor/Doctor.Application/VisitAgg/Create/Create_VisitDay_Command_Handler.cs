

using Common.Application;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.VisitAgg;
using Doctor.Domain.VisitAgg.Repository;

namespace Doctor.Application.VisitAgg.Create;

public class Create_VisitDay_Command_Handler : IBaseCommandHandler<Create_VisitDay_Command>
{
    private readonly IVisitRepository _repository;

    public Create_VisitDay_Command_Handler(IVisitRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(Create_VisitDay_Command request, CancellationToken cancellationToken)
    {
        var visitDay = new VisitDay(request.Title,  request.day);
        _repository.Add(visitDay);
        await _repository.Save();
        return OperationResult.Success();
    }
}
