
using Common.Application;
using Doctor.Application.ContactUsAgg.Create;
using Doctor.Application.ContactUsAgg.Edit;
using Doctor.Application.ContactUsAgg.Remove;
using Doctor.Query.ContactUsAgg.DTOs;
using Doctor.Query.ContactUsAgg.Get;
using MediatR;

namespace Doctor.Presentation.Facade.ContactUsAgg;

public class ContactUsFacade : IContactUsFacade
{
    private readonly IMediator _mediator;

    public ContactUsFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> Create(Create_ContactUs_Command command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(Edit_ContactUs_Command command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> Remove(long Id)
    {
        return await _mediator.Send(new Remove_ContactUs_Command(Id));
    }
    public async Task<ContactUsDto> GetContactUs()
    {
        return await _mediator.Send(new Get_ContactUs_Query());
    }

  
}
