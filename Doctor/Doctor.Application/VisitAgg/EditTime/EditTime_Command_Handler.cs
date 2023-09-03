

using Common.Application;
using Doctor.Domain.VisitAgg;
using Doctor.Domain.VisitAgg.Repository;

namespace Doctor.Application.VisitAgg.EditTime;

public class EditTime_Command_Handler : IBaseCommandHandler<EditTime_Command>
{
    private readonly IVisitRepository _repository;

    public EditTime_Command_Handler(IVisitRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(EditTime_Command request, CancellationToken cancellationToken)
    {
        var res = await _repository.EditVisitTime(request.VisitDayId,request.Id);
        if(res==false)
            return OperationResult.NotFound();

        return OperationResult.Success();
    }
}
