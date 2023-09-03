

using Common.Application;
using Doctor.Domain.VisitAgg;
using Doctor.Domain.VisitAgg.Repository;

namespace Doctor.Application.VisitAgg.AddTime;

public class AddTime_Command_Handler : IBaseCommandHandler<AddTime_Command>
{
    private readonly IVisitRepository _repository;

    public AddTime_Command_Handler(IVisitRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(AddTime_Command request, CancellationToken cancellationToken)
    {
        var res =await _repository.AddVisitTime(request.VisitDayId,request.StartTime,request.EndTime);
        if(res == false)
            return OperationResult.NotFound();
 
        return OperationResult.Success();   
    }
}

