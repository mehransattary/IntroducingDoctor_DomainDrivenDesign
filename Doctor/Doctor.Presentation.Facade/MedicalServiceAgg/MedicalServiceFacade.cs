using Common.Application;
using Doctor.Application.MedicalServiceAgg.Create;
using Doctor.Application.MedicalServiceAgg.Edit;
using Doctor.Application.MedicalServiceAgg.Remove;
using Doctor.Domain.MedicalServicesAgg;
using Doctor.Query.MedicalServiceAgg.DTOs;
using Doctor.Query.MedicalServiceAgg.GetById;
using Doctor.Query.MedicalServiceAgg.GetList;
using MediatR;


namespace Doctor.Presentation.Facade.MedicalServiceAgg;
public class MedicalServiceFacade : IMedicalServiceFacade
{
    private readonly IMediator _mediator;

    public MedicalServiceFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(Create_MedicalService_Command command)
    {
       return await _mediator.Send(command);
    }

    public async Task<OperationResult<long>> Edit(Edit_MedicalService_Command command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> Remove(long medicalServiceId)
    {
        return await _mediator.Send(new Remove_MedicalService_Command(medicalServiceId));
    }
    public async Task<MedicalServiceDto> GetById(long medicalServiceId)
    {
        return await _mediator.Send(new Get_MedicalService_By_Id_Query(medicalServiceId));
    }

    public async Task<List<MedicalServiceDto>> GetList()
    {
        return await _mediator.Send(new GetList_MedicalService_Query());
    }


}
