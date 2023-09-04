

using Common.Application;
using Doctor.Application.VisitAgg.AddTime;
using Doctor.Application.VisitAgg.Create;
using Doctor.Application.VisitAgg.Edit;
using Doctor.Application.VisitAgg.EditTime;
using Doctor.Application.VisitAgg.Remove;
using Doctor.Query.VisitAgg.DTOs;
using Doctor.Query.VisitAgg.GetByDayId;
using Doctor.Query.VisitAgg.GetList;
using MediatR;

namespace Doctor.Presentation.Facade.VisitAgg;

public class VisitDayFacade : IVisitDayFacade
{
    private readonly IMediator _mediator;

    public VisitDayFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddTime(AddTime_Command command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> EditTime(EditTime_Command command)
    {
        return await _mediator.Send(command);
    }


    public async Task<OperationResult> Create(Create_VisitDay_Command command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<long>> Edit(Edit_VisitDay_Command command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> Remove(long visitDayId)
    {
        return await _mediator.Send(new Remove_VisitDay_Command(visitDayId));
    }


    public async Task<VisitDayDto> GetById(long visitDayId)
    {
        return await _mediator.Send(new Get_VisitDay_By_Id_Query(visitDayId)) ;
    }

    public async Task<List<VisitDayDto>> GetList()
    {
        return await _mediator.Send(new GetList_VisitDay_Query());
    }

  
}
