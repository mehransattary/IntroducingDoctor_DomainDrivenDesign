

using Common.Application;
using Doctor.Domain.VisitAgg.Repository;

namespace Doctor.Application.VisitAgg.Remove;

public class Remove_VisitDay_Command_Handler : IBaseCommandHandler<Remove_VisitDay_Command>
{
    private readonly IVisitRepository _repository;

    public Remove_VisitDay_Command_Handler(IVisitRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(Remove_VisitDay_Command request, CancellationToken cancellationToken)
    {
            
        var res=  await _repository.DeleteVisitDay(request.Id);
        if(res==false)
            return OperationResult.NotFound();

        return OperationResult.Success();
    }
}
