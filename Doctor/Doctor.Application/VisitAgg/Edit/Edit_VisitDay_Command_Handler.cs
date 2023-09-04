

using Common.Application;
using Doctor.Domain.VisitAgg.Repository;

namespace Doctor.Application.VisitAgg.Edit;

public class Edit_VisitDay_Command_Handler : IBaseCommandHandler<Edit_VisitDay_Command, long>
{
    private readonly IVisitRepository _repository;

    public Edit_VisitDay_Command_Handler(IVisitRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult<long>> Handle(Edit_VisitDay_Command request, CancellationToken cancellationToken)
    {
        var visitDay =await _repository.GetTracking(request.Id);
        if (visitDay == null) 
            return OperationResult<long>.NotFound();

        visitDay.Edit(request.Title, request.day);
        await _repository.Save();
        return OperationResult<long>.Success(request.Id);

    }
}
