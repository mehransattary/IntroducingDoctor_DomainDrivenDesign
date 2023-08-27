
using Common.Application;
using Doctor.Application.AboutUsAgg.Create;
using Doctor.Application.AboutUsAgg.Edit;
using Doctor.Application.AboutUsAgg.Remove;
using Doctor.Query.AboutUsAgg.DTOs;
using Doctor.Query.AboutUsAgg.GetById;
using MediatR;

namespace Doctor.Presentation.Facade.AboutUsAgg;

public class AboutUsFacade : IAboutUsFacade
{
    private readonly IMediator _mediator;

    public AboutUsFacade(IMediator mediator)
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
        return await _mediator.Send(new Remove_AboutUs_Command(Id));
    }
    public async Task<AboutUsDto> GetAboutUs()
    {
        return await _mediator.Send(new Get_AboutUs_Query());
    }

  
}
