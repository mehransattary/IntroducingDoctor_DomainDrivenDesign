
using Common.Application;
using Doctor.Application.DoctorInformationAgg.Create;
using Doctor.Application.DoctorInformationAgg.Edit;
using Doctor.Application.DoctorInformationAgg.Remove;
using Doctor.Query.DoctorInformationAgg.DTOs;
using Doctor.Query.DoctorInformationAgg.GetById;
using Doctor.Query.DoctorInformationAgg.GetList;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Doctor.Presentation.Facade.DoctorInformationAgg;

public class DoctorInformationFacade : IDoctorInformationFacade
{
    private readonly IMediator _mediator;

    public DoctorInformationFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> Create(Create_DoctorInfo_Command command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(Edit_DoctorInfo_Command command)
    {
        return await _mediator.Send(command);
    }

    public async Task<DoctorInformationDto> GetById(long Id)
    {
        return await _mediator.Send(new Get_DoctorInfo_By_Id_Query(Id));
    }

    public async Task<List<DoctorInformationDto>> GetList()
    {
        return await _mediator.Send(new GetList_DoctorInfo_Query());
    }

    public async Task<OperationResult> Remove(long Id)
    {
        return await _mediator.Send(new Remove_DoctorInfo_Command(Id));
    }
}
